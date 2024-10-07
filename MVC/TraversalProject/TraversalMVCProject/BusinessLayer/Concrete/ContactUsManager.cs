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
    public class ContactUsManager : IContactUsService
    {
        IContactUsDal _contactUsDal;
        public ContactUsManager(IContactUsDal contactUsDal)
        {
            _contactUsDal = contactUsDal;
        }
        public void Add(ContactUs entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ContactUs entity)
        {
            throw new NotImplementedException();
        }

        public ContactUs GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetList()
        {
            return _contactUsDal.GetList();
        }

        public void TContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> TGetListContactUsByFalse()
        {
            return _contactUsDal.GetListContactUsByFalse();
        }

        public List<ContactUs> TGetListContactUsByTrue()
        {
            return _contactUsDal.GetListContactUsByTrue();
        }

        public void Update(ContactUs entity)
        {
            throw new NotImplementedException();
        }
    }
}
