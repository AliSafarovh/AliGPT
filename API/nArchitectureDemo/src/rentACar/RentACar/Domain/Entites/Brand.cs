using CorePersistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entites
{
    public class Brand:Entity<Guid>
    {
        public  string Name { get; set; }

        public Brand()
        {
            
        }
        public Brand(Guid id,string name)
        {
            Id = id;
            Name = name;    
        }

    }
}
