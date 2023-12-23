using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Admin/About")]
        public IActionResult Index()
        {
            var result = _aboutService.GetList().FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        [Route("Admin/About")]
        public IActionResult Index(About about)
        {
            _aboutService.Update(about);
            return RedirectToAction("Index");
        }
    }
}
