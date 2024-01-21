using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class MessageController : Controller
    {
        ITestimonialService _testimonialService;

        public MessageController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage(Testimonial testimonial)
        {
            testimonial.Status = false;
            testimonial.Created = DateTime.Now;

            _testimonialService.Add(testimonial);


            return RedirectToAction("Index","Default");
        }
    }
}
