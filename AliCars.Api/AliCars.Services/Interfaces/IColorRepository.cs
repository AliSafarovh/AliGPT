using AliCars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Services.Interfaces
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        public void Update(int id, Color color);
    }
}
