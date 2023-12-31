﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExperienceService
    {
        void Add(Experience experience);
        List<Experience> GetList();
        void Delete(Experience experience);
        void Update(Experience experience);
        Experience Get(int Id);
    }
}
