namespace dotInstrukcije.API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public int InstructionsCount { get; set; }
        public ICollection<Subject>? Subjects { get; set; }
    }
}
