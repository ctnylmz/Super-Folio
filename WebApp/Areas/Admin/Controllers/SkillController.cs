using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SkillController : Controller
    {
        ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [Route("Admin/Skill")]
        public IActionResult Index()
        {
            var message = TempData["Message"] as string;

            ViewData["Message"] = message;

            var result = _skillService.GetList();

            return View(result);
        }

        [Route("Admin/Skill/Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("Admin/Skill/Add")]
        [HttpPost]
        public IActionResult Add(Skill skill)
        {
            _skillService.Add(skill);

            TempData["Message"] = "Successfully Added";


            return RedirectToAction("Index");
        }

        [Route("Admin/Skill/Delete/{Id}")]
        [HttpGet]
        public IActionResult Add(int Id)
        {
            var skill = _skillService.Get(Id);

            _skillService.Delete(skill);

            TempData["Message"] = "Successfully Deleted";


            return RedirectToAction("Index");

        }

        [Route("Admin/Skill/Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var skill = _skillService.Get(id);
            return View(skill);
        }

        [Route("Admin/Skill/Update/{id}")]
        [HttpPost]
        public IActionResult Update(Skill skill)
        {
            _skillService.Update(skill);

            TempData["Message"] = "Successfully Updated";


            return RedirectToAction("Index");
        }
    }
}
