using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {

        private readonly SuperFolioContext _context;

        public DefaultController(SuperFolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        [Route("PortfolioDetails/{id}")]
        public IActionResult PortfolioDetails(int id)
        {
            var result = _context.Portfolios.Find(id);
            return View(result);
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
    }
}
