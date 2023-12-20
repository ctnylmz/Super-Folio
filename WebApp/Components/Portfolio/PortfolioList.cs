using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Portfolio
{
    public class PortfolioList : ViewComponent
    {
        IPortfolioService _portfolioService;

        public PortfolioList(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _portfolioService.GetList();

            return View(result);
        }
    }
}
