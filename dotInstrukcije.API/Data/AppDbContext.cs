using dotInstrukcije.API.Models;
using Microsoft.EntityFrameworkCore;

namespace dotInstrukcije.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<InstructionsDate> InstructionsDates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ivan", Surname = "Horvat" },
                new Student { Id = 2, Name = "Ana", Surname = "Kralj" }
                // Add more students here
            );
        }
    }
}
