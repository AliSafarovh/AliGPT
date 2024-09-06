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
            throw new NotImplementedException();
        }

        public void Delete(Destination entity)
        {
            throw new NotImplementedException();
        }

        public Destination GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Destination> GetList()
        {
            return _destinationalDal.GetList();
        }

        public void Update(Destination entity)
        {
            throw new NotImplementedException();
        }
    }
}
