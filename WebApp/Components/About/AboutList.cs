using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.About
{
    public class AboutList : ViewComponent
    {
        IAboutService _aboutService;

        public AboutList(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _aboutService.GetList();

            return View(result);
        }
    }
}
