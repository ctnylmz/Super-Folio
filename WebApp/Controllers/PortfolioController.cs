using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class PortfolioController : Controller
    {
        IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [Route("PortfolioDetails/{id}")]
        public IActionResult PortfolioDetails(int id)
        {
           var result = _portfolioService.Get(id);
            return View(result);
        }
    }
}
