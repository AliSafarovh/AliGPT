using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApi.Data.Entities
{
    public class Group:BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }


    }
}
