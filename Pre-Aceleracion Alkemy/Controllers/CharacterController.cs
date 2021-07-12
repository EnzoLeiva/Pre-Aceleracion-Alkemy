using Microsoft.AspNetCore.Mvc;
using Pre_Aceleracion_Alkemy.Dto.Personaje;
using Pre_Aceleracion_Alkemy.Pre_AceleracionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly Pre_AceleracionDb context;

        public CharacterController(Pre_AceleracionDb context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetPersonajes()
        {
            var listaPersonajes = context.Characters.ToList();
            var listaDto = new List<CharacterDto>();
            foreach(var l in listaPersonajes)
            {
                var dto = new CharacterDto
                {
                    Imagen = l.Image,
                    Nombre = l.Name
                };
                listaDto.Add(dto);
            }
            return Ok(listaDto); 
        }
    }
}
