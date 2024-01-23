using Business.Abstract;
using Core.Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
        public async Task<IActionResult> Index(AboutVM about)
        {
            var user = _aboutService.GetList().FirstOrDefault();

            if (about.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(about.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/photo/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await about.ImageFile.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }

            user.Title = about.Title;
            user.Description = about.Description;
            user.Age = about.Age;
            user.Email = about.Email;
            user.Phone = about.Phone;
            user.Address = about.Address;

            await _aboutService.UpdateAsync(user);

            TempData["Message"] = "Successfully Updated";

            return RedirectToAction("Index");

        }
    }
}
