using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExperienceController : Controller
    {
        IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [Route("Admin/Experience")]
        public IActionResult Index()
        {
            var result = _experienceService.GetList();
            return View(result);
        }

        [Route("Admin/Experience/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/Experience/Add")]
        public IActionResult Add(Experience experience)
        {
            _experienceService.Add(experience);
            return RedirectToAction("Index");
        }

        [Route("Admin/Experience/Update/{id}")]
        public IActionResult Update(int id)
        {
            var result = _experienceService.Get(id);
            return View(result);
        }

        [HttpPost]
        [Route("Admin/Experience/Update/{id}")]
        public IActionResult Update(Experience experience)
        {
            _experienceService.Update(experience);
            return RedirectToAction("Index");

        }

        [Route("Admin/Experience/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var experience = _experienceService.Get(id);
            _experienceService.Delete(experience);
            return RedirectToAction("Index");
        }
    }
}
