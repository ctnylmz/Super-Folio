using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Service
{
    public class ServiceList : ViewComponent
    {
        IService _service;

        public ServiceList(IService service)
        {
            _service = service;
        }

        public IViewComponentResult Invoke()
        {
            var result = _service.GetList();

            return View(result);
        }
    }
}
