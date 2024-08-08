using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.DTOs.Groups;
using UniversityApi.Data.Entities;

namespace UniversityApi.Data.DTOs.Student
{
    public class StudentGetDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image {get; set; }
        public DateTime Birthday { get; set; }
        public GroupGetDTO Group  { get; set; }
    }
}
