using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
