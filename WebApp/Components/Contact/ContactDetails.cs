using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Contact
{
    public class ContactDetails : ViewComponent
    {
        IContactDal _contactDal;

        public ContactDetails(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IViewComponentResult Invoke()
        {
            var result = _contactDal.GetList();
            return View(result);
        }
    }
}
