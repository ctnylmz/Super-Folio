using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Skill
{
    public class SkillList : ViewComponent
    {
        ISkillService _skillService;

        public SkillList(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _skillService.GetList();

            return View(result);
        }
    }
   
}
