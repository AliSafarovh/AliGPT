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
    public class TestimonialManager:ITestimonialService
    {
        ITestimonailDal _testimonial;
        public TestimonialManager(ITestimonailDal testimonailDal)
        {
            _testimonial = testimonailDal;
        }

        public void Add(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Testimonial entity)
        {
            throw new NotImplementedException();
        }

        public Testimonial GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetList()
        {
           return _testimonial.GetList();
        }

        public void Update(Testimonial entity)
        {
            throw new NotImplementedException();
        }
    }
}
