using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    internal class ServiceManager : IService
    {
        IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public void Add(Service service)
        {
            _serviceDal.Add(service);
        }

        public void Delete(Service service)
        {
            _serviceDal.Delete(service);
        }

        public Service Get(int Id)
        {
          return _serviceDal.Get(s => s.Id == Id);
        }

        public List<Service> GetList()
        {
            return _serviceDal.GetList().ToList();

        }

        public void Update(Service service)
        {
            _serviceDal.Update(service);
        }
    }
}
