using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.Entities;

namespace UniversityApi.Service.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
   
        public void Update(int id, Group group);
    }
}
