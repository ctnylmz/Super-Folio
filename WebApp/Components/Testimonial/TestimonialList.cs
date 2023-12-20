using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        ITestimonialService _testimonialService;

        public TestimonialList(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _testimonialService.GetList();
            return View(result);
        }
    }
}
