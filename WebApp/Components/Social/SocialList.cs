using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Social
{
    [ViewComponent(Name = "SocialList")]

    public class SocialList : ViewComponent
    {
    
        ISocialService _socialService;

        public SocialList(ISocialService socialService)
        {
            _socialService = socialService;
        }

        public IViewComponentResult Invoke()
        {
            var result = _socialService.GetList().Where(t => t.Status == true);
            return View(result);
        }
    }
}
