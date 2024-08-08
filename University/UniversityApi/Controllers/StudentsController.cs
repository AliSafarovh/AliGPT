using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using UniversityApi.Data.DTOs.Student;
using UniversityApi.Data.Entities;
using UniversityApi.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        private readonly IFileRepository _fileRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;
        private readonly IValidator<StudentPostDTO> _validator;
        public StudentsController(IFileRepository fileRepository,
            IStudentRepository studentRepository,
            IMapper mapper,
            IWebHostEnvironment env,
            IValidator<StudentPostDTO> validator)
        {
            _env = env;
            _fileRepository = fileRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
            _validator = validator;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Student> students = _studentRepository.GetAllStudentsWithDetail();
            List<StudentGetDTO> data = _mapper.Map<List<StudentGetDTO>>(students);
            return Ok(data);
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Student student = _studentRepository.GetStudentWithDetail(id);
            if (student is null) return NotFound();
            StudentGetDTO data = _mapper.Map<StudentGetDTO>(student);
            return Ok(data);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] StudentPostDTO entity)
        {
            try
            {
                Student student = _mapper.Map<Student>(entity);
                ValidationResult result = _validator.Validate(entity);
                if (!result.IsValid)
                {
                    return BadRequest(new
                    {
                        Status = "error",
                        Messages = result.Errors.Select(x => x.ErrorMessage).ToList()
                    });
                }
                if (entity.File != null)
                {
                    student.Image = await _fileRepository.FileUpload(_env.WebRootPath, "students", entity.File);
                }
                _studentRepository.Add(student);
                return CreatedAtAction(nameof(Get), new
                {
                    Status = "success",
                    Message = "Successfully created",
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "error",
                    Message = ex.Message,
                });
            }
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] StudentPostDTO entity)
        {
            try
            {
                Student studentDb = _studentRepository.GetById(id);
                if (studentDb is null) return NotFound();
                Student student = _mapper.Map<Student>(entity);
                if (entity.File != null)
                {
                    _fileRepository.FileDelete(_env.WebRootPath, "students", studentDb.Image);
                    student.Image = await _fileRepository.FileUpload(_env.WebRootPath, "students", entity.File);
                }
                _studentRepository.Update(id, student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                    Status = "error",
                });
            }
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Student student = _studentRepository.GetById(id);
                if (student == null) return NotFound();
                _fileRepository.FileDelete(_env.WebRootPath, "students", student.Image);
                _studentRepository.Delete(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "error",
                    Message = ex.Message,
                });
            }
        }

    }
}
