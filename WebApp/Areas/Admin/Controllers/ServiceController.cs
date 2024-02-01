using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServiceController : Controller
    {
        IService _service;

        public ServiceController(IService service)
        {
            _service = service;
        }

        [Route("Admin/Service")]
        public IActionResult Index()
        {
            var message = TempData["Message"] as string;

            ViewData["Message"] = message;

            var result = _service.GetList();
            return View(result);
        }

        [Route("Admin/Service/Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("Admin/Service/Add")]
        [HttpPost]
        public async Task<IActionResult> Add(ServiceVM service)
        {

            if (service.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(service.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/services/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await service.ImageFile.CopyToAsync(stream);
                service.ImageUrl = imageName;
            }
          
            var newService = new Service
            {
                Title = service.Title,
                ImageUrl = service.ImageUrl
            };

            _service.Add(newService);

            TempData["Message"] = "Successfully Added";

            return RedirectToAction("Index");
        }

        [Route("Admin/Service/Delete/{Id}")]
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var service = _service.Get(Id);
            _service.Delete(service);
            TempData["Message"] = "Successfully Delete";
            return RedirectToAction("Index");

        }

        [Route("Admin/Service/Update/{id}")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var service = _service.Get(id);
            return View(service);
        }

        [Route("Admin/Service/Update/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(ServiceVM service)
        {
            var user = _service.Get(service.Id);

            if (service.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(service.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/services/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await service.ImageFile.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }
            user.Title = service.Title;

            await _service.UpdateAsync(user);

            TempData["Message"] = "Successfully Updated";



            return RedirectToAction("Index");
        }
    }
}
