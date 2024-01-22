using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
    }
}
