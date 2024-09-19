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
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationdal;
        public ReservationManager(IReservationDal reservationDal)
        {
                _reservationdal = reservationDal;
        }
        public void Add(Reservation entity)
        {
            _reservationdal.Insert(entity);
        }

        public void Delete(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Reservation GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetListApprovalReservation(int id)
        {
           return _reservationdal.GetListByFilter(x=>x.AppUser.Id == id);
        }

        public void Update(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
