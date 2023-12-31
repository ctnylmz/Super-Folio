﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortfolioService
    {
        void Add(Portfolio portfolio);
        List<Portfolio> GetList();
        void Delete(Portfolio portfolio);
        void Update(Portfolio portfolio);
        Portfolio Get(int Id);
    }
}
