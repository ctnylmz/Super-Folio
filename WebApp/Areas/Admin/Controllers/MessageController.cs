using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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

        [Route("Admin/Message/Details/{id}")]
        public IActionResult Details(int id)
        {
            var result = _testimonialService.Get(id);
            return View(result);
        }

        [Route("Admin/Message/Update/{id}")]
        public IActionResult Update(int id)
        {
            var result = _testimonialService.Get(id);
            return View(result);
        }

        [HttpPost]
        [Route("Admin/Message/Update/{id}")]
        public IActionResult Update(Testimonial testimonial)
        {
            try
            {
                _testimonialService.Update(testimonial);
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return View(testimonial);
            }
        }


        [Route("Admin/Message/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var testimonial = _testimonialService.Get(id);
            _testimonialService.Delete(testimonial);
            return RedirectToAction("Index");
        }
    }
}
