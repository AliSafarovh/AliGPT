using LibraryApi.Data.Entities;
using LibraryApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Service.Implementations
{
    public class AuthorService : GenericService<Author>, IAuthorRepository
    {
        public AuthorService(ApplicationDbContext context) : base(context)
        {

        }

        public void Update(int id, Author author)
        {
            Author authordb=GetById(id);
            if (authordb != null)
            {
                authordb.Name = author.Name;
                authordb.UpdatedAt = DateTime.Now;
            }
            _context.SaveChanges();
        }
    }
}
