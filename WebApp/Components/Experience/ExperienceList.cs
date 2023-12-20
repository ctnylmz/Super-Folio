using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Experience
{
    public class ExperienceList : ViewComponent
    {
        IExperienceService _experienceService;

        public ExperienceList(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _experienceService.GetList();
            return View(result);
        }
    }
}
