using AliCars.Data.DTOs.CategoryDTO;
using AliCars.Data.Entities;
using AliCars.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AliCars.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _CategoryRepository;
        public CategoriesController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> Categories = _CategoryRepository.GetAll();
            return Ok(Categories);
        }
        [HttpPost]
        public IActionResult Create([FromForm] CategoryPostDTO model)
        {
            Category category = new Category
            {
                Name = model.Name,
            };
            _categoryRepository.Add(Category);
            return CreatedAtAction(nameof(Index), _CategoryRepository.GetAll());
        }

        [HttpGet("{id?}")]
        public IActionResult Details(int? id)
        {
            Category Category = _CategoryRepository.GetById(id);
            List<CategoryGetDTO> data = new List<CategoryGetDTO>();
            foreach (var category in categories) 
            {
                data.Add(new CategoryGetDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                });
                    }
            return Ok(data);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] CategoryPostDTO model)
        {
            Category category = new Category
            {
                Name = model.Name,
            };
            _CategoryRepository.Update(id, Category);
            return NoContent();
        }

        [HttpDelete("{id?}")]
        public IActionResult Delete(int id)
        {
            _CategoryRepository.Delete(id);
            return NoContent();
        }
    }
}
