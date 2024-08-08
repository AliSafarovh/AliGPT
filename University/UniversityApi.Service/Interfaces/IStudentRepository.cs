using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.Entities;

namespace UniversityApi.Service.Interfaces
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        public List<Student> GetAllStudentsWithDetail();
        public Student GetStudentWithDetail(int id);
        public void Update(int id, Student student);
    }
}
