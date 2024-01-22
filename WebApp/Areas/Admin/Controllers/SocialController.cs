using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialController : Controller
    {

        ISocialService _socialService;

        public SocialController(ISocialService socialService)
        {
            _socialService = socialService;
        }

        [Route("Admin/Social")]
        public IActionResult Index()
        {
            var result = _socialService.GetList();
            return View(result);
        }

        [Route("Admin/Social/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/Social/Add")]
        public IActionResult Add(SocialMedia socialMedia)
        {
            _socialService.Add(socialMedia);
            return RedirectToAction("Index");
        }

        [Route("Admin/Social/Update/{id}")]
        public IActionResult Update(int id)
        {
            var result = _socialService.Get(id);
            return View(result);
        }

        [HttpPost]
        [Route("Admin/Social/Update/{id}")]
        public IActionResult Update(SocialMedia socialMedia)
        {
            _socialService.Update(socialMedia);
            return RedirectToAction("Index");

        }

        [Route("Admin/Social/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var socialMedia = _socialService.Get(id);
            _socialService.Delete(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
