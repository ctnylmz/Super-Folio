using Core.DataAcess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTestimonialDal : EfEntityRepositoryBase<Testimonial, SuperFolioContext>, ITestimonialDal
    {
        SuperFolioContext _context;

        public EfTestimonialDal(SuperFolioContext context)
        {
            _context = context;
        }

        public List<Testimonial> GetLastThreeTestimonials()
        {
            return _context.Testimonials.OrderByDescending(t => t.Created).Take(3).ToList();
        }
    }
}
