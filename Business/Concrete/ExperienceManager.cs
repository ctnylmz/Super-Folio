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
    public class ExperienceManager : IExperienceService
    {
        IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public void Add(Experience experience)
        {
            _experienceDal.Add(experience);
        }

        public void Delete(Experience experience)
        {
            _experienceDal.Delete(experience);
        }

        public Experience Get(int Id)
        {
          return _experienceDal.Get(e => e.Id == Id);
        }

        public List<Experience> GetList()
        {
            return _experienceDal.GetList().ToList();
        }

        public void Update(Experience experience)
        {
            _experienceDal.Update(experience);
        }
    }
}
