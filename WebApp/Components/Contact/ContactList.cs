using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Contact
{
    public class ContactList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
