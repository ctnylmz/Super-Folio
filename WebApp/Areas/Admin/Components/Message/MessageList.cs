using Business.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Components.Message
{
    [ViewComponent(Name = "MessageList")]

    public class MessageList : ViewComponent
    {
        ITestimonialService _testimonialService;

        public MessageList(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _testimonialService.GetLastThreeTestimonials();
            return View(result);
        }
    }
}

