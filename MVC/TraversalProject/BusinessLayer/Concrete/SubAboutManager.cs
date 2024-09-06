using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {
        ISubAboutDal _subAboutDal;
        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public void Add(SubAbout entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubAbout entity)
        {
            throw new NotImplementedException();
        }

        public SubAbout GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> GetList()
        {
            return _subAboutDal.GetList();
        }

        public void Update(SubAbout entity)
        {
            throw new NotImplementedException();
        }
    }
}
