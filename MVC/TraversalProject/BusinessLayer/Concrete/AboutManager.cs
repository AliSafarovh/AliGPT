using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;
        public AboutManager(IAboutDal aboutDal)
        {
                _aboutdal = aboutDal;
        }

        public void Add(About entity)
        {
            _aboutdal.Insert(entity);
        }

        public void Delete(About entity)
        {
           _aboutdal.Delete(entity);
        }

        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutdal.GetList(); 
        }

        public void Update(About entity)
        {
           _aboutdal.Update(entity);    
        }
    }
}
