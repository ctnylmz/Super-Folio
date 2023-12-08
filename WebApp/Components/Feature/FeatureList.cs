using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        IFeatureService _featureService;
        
        public FeatureList(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public IViewComponentResult Invoke()
        {
          var result = _featureService.GetList();

            return View(result);
        }
    }
}
