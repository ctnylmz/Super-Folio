using Business.Abstract;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Components.Service
{
    public class ServiceList : ViewComponent
    {
        IServiceDal _serviceDal;

        public ServiceList(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public IViewComponentResult Invoke()
        {
            var result = _serviceDal.GetList();

            return View(result);
        }
    }
}
