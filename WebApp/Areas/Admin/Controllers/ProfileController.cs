using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("Admin/Profile")]
        public async Task<IActionResult> Index()
        {
            var result = await _userManager.GetUserAsync(User);

            return View(result);
        }

        [Route("Admin/Profile")]
        [HttpPost]
        public async Task<IActionResult> Index(User entity)
        {
            var user = await _userManager.GetUserAsync(User);
            
            if(entity.ProfileImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(entity.ProfileImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/Admin/images/faces/" + imageName;
                var stream = new FileStream(saveLocation,FileMode.Create);
                await entity.ProfileImageFile.CopyToAsync(stream);
                user.PhoneNumber = imageName;
            }

            user.Email = entity.Email;
            user.UserName = entity.UserName;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Message"] = "Successfully Updated";
                return RedirectToAction("Index");
            }

            return View(entity);
        }

        [Route("Admin/ChangePassword")]
        public IActionResult Password()
        {
            return View();
        }

        [Route("Admin/ChangePassword")]
        [HttpPost]
        public async Task<IActionResult> Password(Password password)
        {
            if (ModelState.IsValid)
            {
                if (password.NewPassword == password.ConfirmPassword)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, password.currentPassword, password.NewPassword);
                    if (changePasswordResult.Succeeded)
                    {
                        TempData["Message"] = "Successfully Updated";
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("currentPassword", "Old Password is Incorrect");
                    }
                }
                else
                {
                    ModelState.AddModelError("currentPassword", "New Password and Again Password Incorrect");
                }
            }

            return View();

        }

    }
}
