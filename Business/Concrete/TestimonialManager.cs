using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void Add(Testimonial testimonial)
        {
            _testimonialDal.Add(testimonial);
        }

        public void Delete(Testimonial testimonial)
        {
            _testimonialDal.Delete(testimonial);
        }

        public Testimonial Get(int Id)
        {
            return _testimonialDal.Get(t => t.Id == Id);
        }

        public List<Testimonial> GetLastThreeTestimonials()
        {
            return _testimonialDal.GetList().OrderByDescending(t => t.Created).Take(3).ToList();
        }

        public List<Testimonial> GetList()
        {
           return _testimonialDal.GetList().ToList();
        }

        public void Update(Testimonial testimonial)
        {
            _testimonialDal.Update(testimonial);
        }
    }
}
