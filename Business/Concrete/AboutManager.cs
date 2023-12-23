using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Update(About about)
        {
          _aboutDal.Update(about);
        }

        void IAboutService.Add(About about)
        {
            _aboutDal.Add(about);
        }

        List<About> IAboutService.GetList()
        {
            return _aboutDal.GetList().ToList();
        }
    }
}
