﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkillService
    {
        void Add(Skill skill);
        List<Skill> GetList();
        void Delete(Skill skill);
        void Update(Skill skill);
        Skill Get(int Id);

    }
}
