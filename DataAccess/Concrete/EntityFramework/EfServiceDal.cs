using Core.DataAcess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfServiceDal : EfEntityRepositoryBase<Service, SuperFolioContext>, IServiceDal
    {
        public async Task UpdateAsync(Service entity)
        {
            using (var context = new SuperFolioContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
