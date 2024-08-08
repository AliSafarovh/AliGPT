using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Data.Entities
{
    public class ApplicationsDbContext:DbContext
    {
        public ApplicationsDbContext(DbContextOptions<ApplicationsDbContext>options):base(options)
        {
        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
