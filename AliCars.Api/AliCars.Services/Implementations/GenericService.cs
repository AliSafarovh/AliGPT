using AliCars.Data.Entities;
using AliCars.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Services.Implementations
{
    public class GenericService<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationsDbContext _context;
        public GenericService(ApplicationsDbContext context)
        {
            _context = context;
        }

        // Dependency injection
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            T entity = _context.Set<T>().FirstOrDefault(c => c.Id == id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}


