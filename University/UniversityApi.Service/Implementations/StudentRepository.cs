using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.Entities;
using UniversityApi.Service.Interfaces;

namespace UniversityApi.Service.Implementations
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Student> GetAllStudentsWithDetail()
        {
            return _context.Students
                .Include(x => x.Group)
                .Where(x => x.DeletedAt == null)
                .ToList();
        }

        public Student GetStudentWithDetail(int id)
        {
            return _context.Students
                .Include(x => x.Group)
                .Where(x => x.DeletedAt == null)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(int id, Student student)
        {
            Student studentDb = GetById(id);
            if (studentDb != null)
            {
                studentDb.Birthday = student.Birthday;
                studentDb.Firstname = student.Firstname;
                studentDb.Lastname = student.Lastname;
                studentDb.Image = student.Image;
                studentDb.GroupId = student.GroupId;
                _context.SaveChanges();
            }
        }
    }
}
