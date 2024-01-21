using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        ITestimonialService _testimonialService;

        public MessageController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [Route("Admin/Message")]
        public IActionResult Index()
        {
            var result = _testimonialService.GetList();
            return View(result);
        }
    }
}
