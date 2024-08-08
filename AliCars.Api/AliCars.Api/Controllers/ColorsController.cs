using AliCars.Data.Entities;
using AliCars.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AliCars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private IColorRepository _colorRepository;
        public ColorsController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Color> colors = _colorRepository.GetAll();
            return Ok(colors);
        }
        [HttpPost]
        public IActionResult Create([FromForm] Color color)
        {
            _colorRepository.Add(color);
            return CreatedAtAction(nameof(Index), _colorRepository.GetAll());
        }

        [HttpGet("{id?}")]
        public IActionResult Details(int? id)
        {
            Color color = _colorRepository.GetById(id);
            if (color is null) return NotFound();
            return Ok(color);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] Color color)
        {
            _colorRepository.Update(id, color);
            return NoContent();
        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(int id)
        {
            _colorRepository.Delete(id);
            return NoContent();
        }
    }
}
    
