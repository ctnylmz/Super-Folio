using Core.Entities.Abstract;

namespace WebApp.Areas.Admin.Models
{
    public class ExperienceVM : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public IFormFile ImageFile { get; set; }

    }
}
