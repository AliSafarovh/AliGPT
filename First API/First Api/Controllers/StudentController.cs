using First_Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace First_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private List<Student> students;

        public StudentController()
        {
            students = new List<Student>
            {
                new Student(1, "Ali", "Safarov"),
                new Student(2, "Yusif", "Hesenli")
            };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost("{id}")]
    
        public IActionResult Create([FromBody] Student newStudent)
        {
            var existingStudent = students.FirstOrDefault(c => c.Id == newStudent.Id);
            if (existingStudent != null)
            {
                return Conflict("Bu ID-li Telebe artiq movcuddur");
            }

            // Burada yeni öğrenciyi listenize eklemeyi unutmayın.
            students.Add(newStudent);

            return Ok(newStudent);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Student student)
        {
            Student studentExisting = students.FirstOrDefault(x => x.Id == id);
            if (studentExisting is null)
            {
                return NotFound();
            }
            studentExisting.Name = student.Name;
            studentExisting.Fullname = student.Fullname;
            return CreatedAtAction(nameof(Index), student);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        { Student student = students.FirstOrDefault(s => s.Id == id);
            if (student is null) return NotFound();
            students.Remove(student);
            return CreatedAtAction(nameof(Index), student);
        }



    }
}
