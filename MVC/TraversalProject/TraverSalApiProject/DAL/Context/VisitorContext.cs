using Microsoft.EntityFrameworkCore;
using TraverSalApiProject.DAL.Entities;

namespace TraverSalApiProject.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DELL; initial catalog=TraversalDbApi; integrated security=true; TrustServerCertificate=True;");
        }

        public DbSet<Visitor>Visitors { get; set; }
    }

}
