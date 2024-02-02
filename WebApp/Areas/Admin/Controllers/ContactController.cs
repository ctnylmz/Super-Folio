using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class ContactController : Controller
    {
        IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
       
        [Route("Admin/Contact")]
        public IActionResult Index()
        {
            var result = _contactService.GetList().FirstOrDefault();

            if (result == null)
            {
                var newContact = new Contact
                {
                    Title = "",
                    description = "",
                    Email = "",
                    Phone = "",
                };

                _contactService.Add(newContact);

                return RedirectToAction("Index");
            }


            return View(result);
        }

        [HttpPost]
        [Route("Admin/Contact")]
        public IActionResult Index(Contact contact)
        {
            _contactService.Update(contact);

            TempData["Message"] = "Successfully Updated";

            return RedirectToAction("Index");
        }
    }
}
