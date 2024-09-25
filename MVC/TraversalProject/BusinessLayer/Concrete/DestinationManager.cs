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
    public class DestinationManager : IDestinationService
    {

        IDestinationDal _destinationalDal;
        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationalDal = destinationDal;
        }
        public void Add(Destination entity)
        {
            _destinationalDal.Insert(entity);
        }

        public void Delete(Destination entity)
        {
           _destinationalDal.Delete(entity);
        }

        public Destination GetByID(int id)
        {
           return _destinationalDal.GetById(id);
        }   

        public List<Destination> GetList()
        {
            return _destinationalDal.GetList();
        }

        public void Update(Destination entity)
        {
            _destinationalDal.Update(entity);
        }
    }
}
