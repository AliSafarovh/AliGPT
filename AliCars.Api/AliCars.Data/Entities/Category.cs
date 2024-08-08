using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Data.Entities
{
    public class Category:BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }    
    }
}
