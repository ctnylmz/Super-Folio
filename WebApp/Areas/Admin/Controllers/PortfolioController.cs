using Autofac.Core;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Areas.Admin.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
            var message = TempData["Message"] as string;

            ViewData["Message"] = message;

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
        public async Task<IActionResult> Add(PortfolioVM portfolio)
        {
            if (portfolio.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(portfolio.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/portfolio/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await portfolio.ImageFile.CopyToAsync(stream);
                portfolio.ImageUrl = imageName;
            }

            var newPortfolio = new Portfolio
            {
                Name = portfolio.Name,
                ImageUrl = portfolio.ImageUrl,
                Description = portfolio.Description,
            };

            _portfolioService.Add(newPortfolio);


            TempData["Message"] = "Successfully Added";

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
        public async Task<IActionResult> Update(PortfolioVM portfolio)
        {
            var user = _portfolioService.Get(portfolio.Id);

            if (portfolio.ImageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(portfolio.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/portfolio/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await portfolio.ImageFile.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }

            user.Name = portfolio.Name;
            user.Description = portfolio.Description;

            _portfolioService.Update(user);

            TempData["Message"] = "Successfully Updated";

            return RedirectToAction("Index");
        }

        [Route("Admin/Portfolio/Delete/{id}")]
        public IActionResult Delete(int id)
        {
           var portfolio = _portfolioService.Get(id);

           _portfolioService.Delete(portfolio);

            TempData["Message"] = "Successfully Delete";


            return RedirectToAction("Index");
        }
    }
}
