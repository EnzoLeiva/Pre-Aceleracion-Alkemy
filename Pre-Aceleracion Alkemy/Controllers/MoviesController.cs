using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pre_Aceleracion_Alkemy.Dto.Character;
using Pre_Aceleracion_Alkemy.Dto.Movie;
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
    public class MoviesController : ControllerBase
    {
        private readonly Pre_AceleracionDb _context;

        public MoviesController(Pre_AceleracionDb context)
        {
            this._context = context;
        }

        [HttpPost]
        [Route("createMovie")]
        [ActionName(nameof(CreateMovie))]
        public async Task<ActionResult<Movie>> CreateMovie(MovieResponseDto dto)
        {
            var previous = await _context.Movies.FirstOrDefaultAsync(x => x.Title == dto.Title);

            if (previous != null)
            {
                return BadRequest($"{dto.Title} movie already exists");
            }
            var movieEntity = new Movie
            {
                Image = dto.Image,
                Title = dto.Title,
                CreationDate = dto.CreationDate,
                Qualification = dto.Qualification,
                GenderID = (int)dto.GenderID
            };

            if (dto.GenderID.GetValueOrDefault() != 0)
            {
                var genre = await _context.Genders.FirstOrDefaultAsync(x => x.GenderID == dto.GenderID.Value);
            }
            if (dto.CharacterID.GetValueOrDefault() != 0)
            {
                var character = await _context.Characters.FirstOrDefaultAsync(x => x.CharacterID == dto.CharacterID.Value);

                if (character != null)
                {
                    movieEntity.Characters.Add(character);
                }
            }

            await _context.Movies.AddAsync(movieEntity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateMovie), new { Title = dto.Title }, dto);
        }

        [HttpPut("editMovie")]
        public async Task<IActionResult> EditMovie(string title, MovieResponseDto dto)
        {
            var checker = await _context.Movies.FirstOrDefaultAsync(x => x.Title == title);
            if (checker.Title != title)
            {
                return BadRequest($"{title} does not exist");
            }
            _context.Entry(dto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("deleteMovie")]
        public async Task<IActionResult> DeleteMovie(string title)
        {
            var checker = await _context.Movies.FirstOrDefaultAsync(x => x.Title == title);
            if (checker != null)
            {
                _context.Movies.Remove(checker);
            }
            else
            {
                return BadRequest($"{title} movie cannot be removed because he does not exist");
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        [Route("movies")]
        public IActionResult GetMovies()
        {
            var listMovies = _context.Movies.ToList();
            var listDto = new List<MovieDto>();
            foreach (var l in listMovies)
            {
                var dto = new MovieDto
                {
                    Image = l.Image,
                    Title = l.Title,
                    CreationDate = l.CreationDate
                };
                listDto.Add(dto);
            }
            return Ok(listDto);
        }

        [HttpGet]
        [Route("detailMovies")]
        public IActionResult DetailMovies()
        {
            var listCharacters = _context.Movies.ToList();
            return Ok(listCharacters);
        }

        [HttpGet]
        [Route("getForTitle")]
        public IActionResult GetMovieForTitle(string tilte)
        {
            var listCharacters = _context.Movies.ToList();
            if (tilte == null)
            {
                listCharacters = _context.Movies.ToList();
            }
            else
            {
                listCharacters = _context.Movies.Where(x => x.Title == tilte).ToList();
            }
            return Ok(listCharacters);
        }

        [HttpGet]
        [Route("getForGenderID")]
        public IActionResult GetMovieForGenderID(int id)
        {
            var listMovies = _context.Movies.ToList();
            if (id == 0)
            {
                listMovies = _context.Movies.ToList();
            }
            else
            {
                listMovies = _context.Movies.Where(x => x.GenderID == id).ToList();
            }
            return Ok(listMovies);
        }

        [HttpGet]
        [Route("getAsc-Desc")]
        public IActionResult GetMovieAscDesc()
        {
            var listMovies =  _context.Movies.OrderByDescending(x => x.MovieID).ToList();
           
            return Ok(listMovies);
        }

    }
}
