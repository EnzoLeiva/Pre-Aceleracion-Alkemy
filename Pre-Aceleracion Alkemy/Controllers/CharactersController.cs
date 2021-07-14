using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pre_Aceleracion_Alkemy.Dto.Character;
using Pre_Aceleracion_Alkemy.Dto.Personaje;
using Pre_Aceleracion_Alkemy.Models;
using Pre_Aceleracion_Alkemy.Pre_AceleracionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pre_Aceleracion_Alkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharactersController : ControllerBase
    {
        private readonly Pre_AceleracionDb _context;

        public CharactersController(Pre_AceleracionDb context)
        {
            this._context = context;
        }
        [HttpPost]
        [Route("createCharacter")]
        public async Task<IActionResult> CreateCharacter(CharacterResponseDto dto)
        {
            var checker = await _context.Characters.FirstOrDefaultAsync(x => x.Name == dto.Name);
            if (checker != null)
            {
                return BadRequest($"{dto.Name} character already exists");
            }
            var character = new Character
            {
                Name = dto.Name,
                Age = dto.Age,
                Story = dto.Story,
                Image = dto.Image,
                Weight = dto.Weight

            };
            if (dto.MovieID.GetValueOrDefault() != 0)
            {
                var movie = await _context.Movies.FirstOrDefaultAsync(x => x.MovieID == dto.MovieID.Value);
                if (movie != null)
                {
                    character.Movies.Add(movie);
                }
            }
            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("deleteCharacter")]
        public async Task<IActionResult> DeleteCharacter(string name)
        {
            var checker = await _context.Characters.FirstOrDefaultAsync(x => x.Name == name);
            if (checker != null)
            {
                _context.Characters.Remove(checker);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest($"{name} character cannot be removed because he does not exist");
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("editCharacter")]
        public async Task<IActionResult> EditCharacter(CharacterResponseDto dto)
        {
            var checker = await _context.Characters.FirstOrDefaultAsync(x => x.Name == dto.Name);
            if (checker != null)
            {
                checker.Name = dto.Name;
                checker.Age = dto.Age;
                checker.Story = dto.Story;
                checker.Image = dto.Image;
                checker.Weight = dto.Weight;
            }
            else
            {
                return BadRequest($"{dto.Name} does not exist");
            }
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        [Route("characters")]
        public IActionResult GetCharacters()
        {
            var listCharacters = _context.Characters.ToList();
            var listDto = new List<CharacterDto>();
            foreach (var l in listCharacters)
            {
                var dto = new CharacterDto
                {
                    Image = l.Image,
                    Name = l.Name
                };
                listDto.Add(dto);
            }
            return Ok(listDto);
        }

        [HttpGet]
        [Route("getForName")]
        public IActionResult GetCharacterForName(string name)
        {
            var listCharacters = _context.Characters.ToList();
            if (name == null)
            {
                listCharacters = _context.Characters.ToList();
            }
            else
            {
                listCharacters = _context.Characters.Where(x => x.Name == name).ToList();
            }
            return Ok(listCharacters);
        }

        [HttpGet]
        [Route("getForAge")]
        public IActionResult GetCharacterForAge(int age)
        {
            var listCharacters = _context.Characters.ToList();
            if (age == 0)
            {
                listCharacters = _context.Characters.ToList();
            }
            else
            {
                listCharacters = _context.Characters.Where(x => x.Age == age).ToList();
            }
            return Ok(listCharacters);
        }

        [HttpGet]
        [Route("getForMovieID")]
        public IActionResult GetCharacterForMovieID(int movieId)
        {
            var listCharacters = _context.Characters.ToList();
            var listMovies = _context.Movies.ToList();
            if (movieId == 0)
            {
                listCharacters = _context.Characters.ToList();
            }
            else
            {
                foreach (var m in listMovies)
                {
                    if (movieId == m.MovieID)
                    {
                        m.Characters = listCharacters;
                    }
                }
            }
            return Ok(listCharacters);
        }

    }
}
