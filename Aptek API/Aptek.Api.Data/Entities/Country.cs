﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptek.Api.Data.Entities
{
    public class Country:BaseEntity
    {
        [MaxLength (25)]
        public string Name { get; set; }

       
    }
}
