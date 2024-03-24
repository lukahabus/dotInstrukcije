using dotInstrukcije.API.Models;

namespace dotInstrukcije.API.Dtos
{
    public class RegisterDto
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public List<string>? Subjects { get; set; }
    }
}
