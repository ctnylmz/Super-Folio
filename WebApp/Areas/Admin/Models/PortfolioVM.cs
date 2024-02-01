using Core.Entities.Abstract;

namespace WebApp.Areas.Admin.Models
{
    public class PortfolioVM : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Description { get; set; }

    }
}
