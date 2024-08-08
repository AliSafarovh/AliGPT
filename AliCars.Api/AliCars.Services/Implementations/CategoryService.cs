using AliCars.Data.Entities;
using AliCars.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Services.Implementations
{
    public class CategoryService : GenericService<Category>, ICategoryRepository
    {
        public CategoryService(ApplicationsDbContext context) : base(context)
        {
        }
        public void Update(int id, Category category)
        {
            Category categoryDb = _context.Categories.Find(id);
            categoryDb.Name = category.Name;
            categoryDb.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
