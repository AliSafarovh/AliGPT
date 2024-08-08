using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Data.Entities
{
    public class Book:BaseEntity
    {
        public string Name{ get; set; }
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public string Image { get; set; }

    }
}
