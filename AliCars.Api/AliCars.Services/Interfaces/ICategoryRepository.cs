using AliCars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Services.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public void Update(int id, Category category);

    }
}
