﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Data.DTOs.GenreDTO
{
    public class GenrePostDTO : GenreGetDTO
    {
        public string Name { get; set; }
    }
}
