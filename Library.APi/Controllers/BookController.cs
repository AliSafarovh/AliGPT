using AutoMapper;
using LibraryApi.Data.DTOs.AuthorDTO;
using LibraryApi.Data.DTOs.BookDTO;
using LibraryApi.Data.Entities;
using LibraryApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<Book> books = _bookRepository.GetAll();
            List<BookGetDTO> data = _mapper.Map<List<BookGetDTO>>(books);
            return Ok(data);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Book book = _bookRepository.GetById(id);
            if (book is null) return NotFound();
            BookGetDTO data = _mapper.Map<BookGetDTO>(book);
            return Ok(data);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromForm] BookPostDTO entity)
        {
            try
            {
                Book book = _mapper.Map<Book>(entity);

                _bookRepository.Add(book);
                _bookRepository.SaveChanges();

                return CreatedAtAction(nameof(Get), new
                {
                    Status = "success",
                    Message = "Successfully created",
                });
            }
            catch (Exception ex)
            {
                var detailedMessage = ex.InnerException?.Message ?? ex.Message;

                return BadRequest(new
                {
                    Status = "Error",
                    Message = detailedMessage,
                });
            }
        }
        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] BookPostDTO entity)
        {
            try
            {
                Book book = _mapper.Map<Book>(entity);
                _bookRepository.Update(id, book);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    Message = ex.Message,
                });
            }
        }
        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Book book = _bookRepository.GetById(id);
                if (book is null) return NotFound();
                _bookRepository.Delete(book.Id);
                return Ok(new
                {
                    Status = "Success",
                    Message = "Successfully deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
        }
    }
}
