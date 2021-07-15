using Jose;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pre_Aceleracion_Alkemy.Dto.Authentificacion;
using Pre_Aceleracion_Alkemy.Models;
using Pre_Aceleracion_Alkemy.Models.Autentication;
using Pre_Aceleracion_Alkemy.SendGrid;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ISendGridService _sendGridService;
        public AuthenticationController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JwtOptions> jwtOptions,
            SignInManager<User> signInManager,
            IConfiguration configuration, 
            ISendGridService sendGridService)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
            this._sendGridService = sendGridService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserInfo model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.User_Name, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _sendGridService.SendEmail(model);
                    return BuildToken(model);
                }
                else
                {
                    return BadRequest("User_name or password invalid");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserInfo model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.User_Name, model.Password, true, true);
                if (result.Succeeded)
                {
                    return BuildToken(model);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private IActionResult BuildToken(UserInfo user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.User_Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(

                issuer: "Disney.com",
                audience: "Disneyy.com",
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });
        }
    }
}
