﻿using LibraryApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.Service.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        List<T> GetAll();

        public T GetById(int? id);

        public void Add(T entity);

        public void Delete(int? id);
    }
}
