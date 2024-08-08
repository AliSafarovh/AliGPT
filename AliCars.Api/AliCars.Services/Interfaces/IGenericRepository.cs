using AliCars.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliCars.Services.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public interface IGenericRepository<T> where T : BaseEntity
        {
            public List<T> GetAll();

            public T GetById(int? id);

            public void Add(T entity);

            public void Delete(int? id);
        } 
    }
}
