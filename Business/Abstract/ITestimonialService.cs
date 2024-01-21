using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITestimonialService
    {
        void Add(Testimonial testimonial);

        void Delete(Testimonial testimonial);
        void Update(Testimonial testimonial);

        List<Testimonial> GetList();

        List<Testimonial> GetLastThreeTestimonials();
        Testimonial Get(int Id);
    }
}
