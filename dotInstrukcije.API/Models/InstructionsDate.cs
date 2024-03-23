namespace dotInstrukcije.API.Models
{
    public class InstructionsDate
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int ProfessorId { get; set; }
        public Professor? Professor { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Status { get; set; }
    }
}
