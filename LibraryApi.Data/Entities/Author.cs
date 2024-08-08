using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Data.Entities
{
    public class Author:BaseEntity
    {
        [MaxLength (30)]
        public string Name { get; set; }

    }
}
