using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApi.Data.Entities;
using UniversityApi.Service.Interfaces;

namespace UniversityApi.Service.Implementations
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void Update(int id, Group group)
        {
            Group groupDb = GetById(id);
            if (groupDb != null)
            {
                groupDb.Name = group.Name;
                groupDb.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
