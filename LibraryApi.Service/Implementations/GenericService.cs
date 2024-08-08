using LibraryApi.Data.Entities;
using LibraryApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Service.Implementations
{
    public class GenericService<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context;
        public GenericService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            T entity=_context.Set<T>().Find(id);
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
