using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SocialManager : ISocialService
    {
        ISocialMediaDal _socialMediaDal;

        public SocialManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void Add(SocialMedia socialMedia)
        {
            _socialMediaDal.Add(socialMedia);
        }

        public void Delete(SocialMedia socialMedia)
        {
            _socialMediaDal.Delete(socialMedia);
        }

        public SocialMedia Get(int Id)
        {
            return _socialMediaDal.Get(s => s.Id == Id);
        }

        public List<SocialMedia> GetList()
        {
            return _socialMediaDal.GetList().ToList();
        }

        public void Update(SocialMedia socialMedia)
        {
            _socialMediaDal.Update(socialMedia);
        }
    }
}
