using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
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
            return RedirectToAction("Index");
        }
    }
}
