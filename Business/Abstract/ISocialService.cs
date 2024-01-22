using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISocialService
    {
        void Add(SocialMedia socialMedia);
        void Delete(SocialMedia socialMedia);
        void Update(SocialMedia socialMedia);
        List<SocialMedia> GetList();

        SocialMedia Get(int Id);
    }
}
