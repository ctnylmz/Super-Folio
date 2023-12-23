using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [Route("/Admin/Default")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
