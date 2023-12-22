using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class DefaultController : Controller
    {

        private readonly SuperFolioContext _context;
        
        IMessageService _messageService;

        public DefaultController(SuperFolioContext context, IMessageService messageService)
        {
            _context = context;
            _messageService = messageService;
        }

        public IActionResult Index()
        {
            return View();
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

        [Route("PortfolioDetails/{id}")]
        public IActionResult PortfolioDetails(int id)
        {
            var result = _context.Portfolios.Find(id);
            return View(result);
        }

        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage(Message message)
        {
            message.Status = false;

            _messageService.Add(message);

            return RedirectToAction("Index");
        }
    }
}
