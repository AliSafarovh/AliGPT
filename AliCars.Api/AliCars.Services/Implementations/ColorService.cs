using AliCars.Data.Entities;
using AliCars.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Services.Implementations
{
    public class ColorService : GenericService<Color>,IColorRepository
    {
        public ColorService(ApplicationsDbContext context) : base(context)
        {
        }

        public void Update(int id, Color color)
        {
            Color colorDb = _context.Colors.Find(id);
            colorDb.Name = color.Name;
            colorDb.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
    }
}
