namespace WebApp.Areas.Admin.Models
{
    public class User
    {
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string? ProfileImage { get; set; }
        public IFormFile? ProfileImageFile { get; set; }
    }
}
