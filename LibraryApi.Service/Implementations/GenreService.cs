using LibraryApi.Data.Entities;
using LibraryApi.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Service.Implementations
{


    public class GenreService : GenericService<Genre>, IGenreRepository
    {
        public GenreService(ApplicationDbContext context) : base(context)
        {
        }

        public void Update(int id, Genre genre)
        {
           Genre genredb=_context.Genres.Find(id);
            genredb.Name = genre.Name;
            genredb.UpdatedAt= DateTime.Now;
            _context.SaveChanges();
        }
    }
}
