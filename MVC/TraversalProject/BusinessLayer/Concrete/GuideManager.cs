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
            _guideDal.Insert(entity);
        }

        public void ChangeToFalseByGuide(int id)
        {
            _guideDal.ChangeToFalseByGuide(id);
        }

        public void ChangeToTrueByGuide(int id)
        {
            _guideDal.ChangeToTrueByGuide(id);
        }

        public void Delete(Guide entity)
        {
          _guideDal.Delete(entity);
        }

        public Guide GetByID(int id)
        {
           return _guideDal.GetById(id);
        }

        public List<Guide> GetList()
        {
            return _guideDal.GetList();
        }

        public void Update(Guide entity)
        {
            _guideDal.Update(entity);
        }
    }
}
