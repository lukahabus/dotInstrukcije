using dotInstrukcije.API.Data;
using dotInstrukcije.API.Dtos;
using dotInstrukcije.API.Models;
using dotInstrukcije.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotInstrukcije.API.Controllers
{
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IJwtGenerator _jwtGenerator;

        public StudentsController(AppDbContext context, IJwtGenerator jwtGenerator)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
        }

        // Register a Student
        [HttpPost("register/student")]
        public async Task<ActionResult> RegisterStudent(RegisterDto registerDto)
        {
            if (await _context.Students.AnyAsync(x => x.Email == registerDto.Email))
                return BadRequest("Email already exists");

            var student = new Student
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Password = registerDto.Password, // Consider hashing the password before storing
                ProfilePictureUrl = registerDto.ProfilePictureUrl
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Registration successful" });
        }

        // Login a Student
        [HttpPost("login/student")]
        public async Task<ActionResult> LoginStudent(LoginDto loginDto)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if (student == null || student.Password != loginDto.Password) // Consider hashing the password before comparing
                return Unauthorized("Invalid email or password");

            var token = _jwtGenerator.CreateToken(student.Email, "Student");

            return Ok(new { success = true, student, token });
        }

        // Get a Specific Student by Email
        [HttpGet("student/{email}")]
        [Authorize]
        public async Task<ActionResult> GetStudent(string email)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Email == email);

            if (student == null)
                return NotFound("Student not found");

            return Ok(new { success = true, student });
        }

        // Get All Students
        [HttpGet("students")]
        [Authorize]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _context.Students.ToListAsync();

            return Ok(new { success = true, students });
        }
    }
}
