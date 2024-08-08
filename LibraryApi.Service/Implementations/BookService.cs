using LibraryApi.Data.Entities;
using LibraryApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Service.Implementations
{
    public class BookService : GenericService<Book>, IBookRepository
    {

        public BookService(ApplicationDbContext context) : base(context)
        {
            
        }
        public void Update(int id, Book book)
        {
            Book bookdb = GetById(id);
            if (bookdb != null)
            {

                bookdb.Name = book.Name;
                bookdb.UpdatedAt = DateTime.Now;
            }
        }

    }
}
