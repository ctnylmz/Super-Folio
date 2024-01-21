using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Contact
{
    public class SendMessage : ViewComponent
    {
        ITestimonialService _testimonialService;

        public SendMessage(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
