using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Pre_Aceleracion_Alkemy.Dto.Authentificacion;
using Pre_Aceleracion_Alkemy.Models;
using Pre_Aceleracion_Alkemy.Models.Autentication;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.SendGrid
{
    public class SendGridService: ISendGridService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SendGridService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task SendEmail(UserInfo user)
        {
            var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("enzo@example.com");
            var to = new EmailAddress(user.Email);

            var htmlContent = "";
            var textContent = ($"Welcome!! Your registration on the platform has been successful your user is {user.User_Name} and your password {user.Password}");

            try
            {
                var message = await Task.Run(() => MailHelper.CreateSingleEmail(from, to, user.User_Name, textContent, htmlContent));
                var response = await client.SendEmailAsync(message);
            }
            catch (Exception)
            {
                throw;
            }          
        }
    }
}
