using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class FeatureController : Controller
    {
       IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Admin/Feature")]
        public IActionResult Index()
        {
            var result = _featureService.GetList().FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        [Route("Admin/Feature")]
        public IActionResult Index(Feature feature)
        {
            _featureService.Update(feature);

            TempData["Message"] = "Successfully Updated";

            return RedirectToAction("Index");
        }
    }
}
