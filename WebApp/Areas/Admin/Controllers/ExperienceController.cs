using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.Models;

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
            var message = TempData["Message"] as string;

            ViewData["Message"] = message;

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
        public async Task<IActionResult> Add(ExperienceVM experience)
        {
            if (experience.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(experience.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/experience/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await experience.ImageFile.CopyToAsync(stream);
                experience.ImageUrl = imageName;
            }

            var newExperience = new Experience
            {
                Name = experience.Name,
                Date = experience.Date,
                Description = experience.Description,
                ImageUrl = experience.ImageUrl,
            };

            _experienceService.Add(newExperience);


            TempData["Message"] = "Successfully Added";

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
        public async Task<IActionResult> Update(ExperienceVM experience)
        {
            var user = _experienceService.Get(experience.Id);

            if (experience.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(experience.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/experience/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await experience.ImageFile.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }

            user.Name = experience.Name;
            user.Date = experience.Date;
            user.Description = experience.Description;

            _experienceService.Update(user);

            TempData["Message"] = "Successfully Updated";

            return RedirectToAction("Index");

        }

        [Route("Admin/Experience/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var experience = _experienceService.Get(id);
            _experienceService.Delete(experience);
            TempData["Message"] = "Successfully Delete";

            return RedirectToAction("Index");
        }
    }
}
