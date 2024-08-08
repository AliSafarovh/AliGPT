using LibraryApi.Data.DTOs.GenreDTO;
using LibraryApi.Data.Entities;
using LibraryApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genrerepository)
        {
            _genreRepository = genrerepository;

        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Genre> genres = _genreRepository.GetAll();
            List<GenreGetDTO> data = new List<GenreGetDTO>();
            foreach (var genre in genres)
            {
                data.Add(new GenreGetDTO
                {
                    Id = genre.Id,
                    Name = genre.Name,
                });
            }

            return Ok(data); 
        }

        [HttpGet("{id}")]
        public IActionResult Details(int? id)
        {
            Genre genre=_genreRepository.GetById(id);
            if(genre is null) return NotFound();
            return Ok(genre);
                    
        }


    [HttpPost]
        public IActionResult Create([FromForm] GenrePostDTO model)
        {
        Genre genre = new Genre
        {
            Name = model.Name,
        };
            _genreRepository.Add(genre);
            return CreatedAtAction(nameof(Index), _genreRepository.GetAll());
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Genre genre)
        {
            _genreRepository.Update(id, genre);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _genreRepository.Delete(id);
            return NoContent();
        }

        
    }
}
