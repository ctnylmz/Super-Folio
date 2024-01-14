using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(Service service)
        {
            _service.Add(service);
            return RedirectToAction("Index");
        }

        [Route("Admin/Service/Delete/{Id}")]
        [HttpGet]
        public IActionResult Add(int Id)
        {
            var service = _service.Get(Id);
            _service.Delete(service);
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
        public IActionResult Update(Service service)
        {
            _service.Update(service);
            return RedirectToAction("Index");
        }
    }
}
