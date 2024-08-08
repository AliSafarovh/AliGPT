using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApi.Data.Entities
{
    public class Student:BaseEntity
    {
        [StringLength(50)]
        public string Firstname {  get; set; }

        [StringLength(50)]
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }

        [StringLength(100)]
        public string Image { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
