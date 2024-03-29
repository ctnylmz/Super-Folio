﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IService
    {
        void Add(Service service);
        List<Service> GetList();
        void Delete(Service service);
        void Update(Service service);
        Task UpdateAsync(Service service);
        Service Get(int Id);
    }
}
