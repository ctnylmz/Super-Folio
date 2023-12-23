using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [Route("Admin/Portfolio")]
        public IActionResult Index()
        {
            var result = _portfolioService.GetList();
            return View(result);
        }

        [Route("Admin/Portfolio/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/Portfolio/Add")]
        public IActionResult Add(Portfolio portfolio)
        {
            _portfolioService.Add(portfolio);
            return RedirectToAction("Index");
        }

        [Route("Admin/Portfolio/Update/{id}")]
        public IActionResult Update(int id)
        {
           var result = _portfolioService.Get(id);
            return View(result);
        }

        [HttpPost]
        [Route("Admin/Portfolio/Update/{id}")]
        public IActionResult Update(Portfolio portfolio)
        {
            _portfolioService.Update(portfolio);
            return RedirectToAction("Index");

        }

        [Route("Admin/Portfolio/Delete/{id}")]
        public IActionResult Delete(int id)
        {
           var portfolio = _portfolioService.Get(id);
           _portfolioService.Delete(portfolio);
            return RedirectToAction("Index");
        }
    }
}
