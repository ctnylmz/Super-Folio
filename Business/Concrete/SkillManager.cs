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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void Add(Skill skill)
        {
            _skillDal.Add(skill);
        }

        public void Delete(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public Skill Get(int Id)
        {
            return _skillDal.Get(s =>s.Id == Id);
        }

        public List<Skill> GetList()
        {
           return _skillDal.GetList().ToList();
        }

        public void Update(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
