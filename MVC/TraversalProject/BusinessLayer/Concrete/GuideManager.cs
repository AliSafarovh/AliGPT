using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        IGuideDal _guideDal;
        public GuideManager(IGuideDal guideDal)
        {
                _guideDal = guideDal;
        }
        public void Add(Guide entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guide entity)
        {
            throw new NotImplementedException();
        }

        public Guide GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Guide> GetList()
        {
            return _guideDal.GetList();
        }

        public void Update(Guide entity)
        {
            throw new NotImplementedException();
        }
    }
}
