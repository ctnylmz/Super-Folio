using Core.DataAcess.Concrete.EntityFramework;
using Core.Entities.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAboutDal : EfEntityRepositoryBase<About, SuperFolioContext>, IAboutDal
    {
        SuperFolioContext _context;

        public EfAboutDal(SuperFolioContext context)
        {
            _context = context;
        }

        public async Task UpdateAsync(About about)
        {
            var existingAbout = await _context.Abouts.FindAsync(about.Id);

            if (existingAbout != null)
            {
                _context.Entry(existingAbout).CurrentValues.SetValues(about);

                await _context.SaveChangesAsync();
            }
        }

    }
}
