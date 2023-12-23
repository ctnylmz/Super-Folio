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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void Add(Portfolio portfolio)
        {
            _portfolioDal.Add(portfolio);
        }

        public void Delete(Portfolio portfolio)
        {
            _portfolioDal.Delete(portfolio);

        }

        public Portfolio Get(int Id)
        {
            return _portfolioDal.Get(p => p.Id == Id);
        }

        public List<Portfolio> GetList()
        {
           return _portfolioDal.GetList().ToList();
        }

        public void Update(Portfolio portfolio)
        {
            _portfolioDal.Update(portfolio);

        }
    }
}
