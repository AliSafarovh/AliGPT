using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApi.Data.DTOs.Student
{
    public class StudentPostDTO
    {
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }  
        public int GroupId { get; set; }
        public IFormFile? File { get; set; } 
    }
}
