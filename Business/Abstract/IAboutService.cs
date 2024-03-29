﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        void Add(About about);
        void Update(About about);
        Task UpdateAsync(About about);
        List<About> GetList();
    }
}
