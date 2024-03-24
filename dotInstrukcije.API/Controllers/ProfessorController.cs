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
    public class ProfessorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IJwtGenerator _jwtGenerator;

        public ProfessorController(AppDbContext context, IJwtGenerator jwtGenerator)
        {
            _context = context;
            _jwtGenerator = jwtGenerator;
        }

        // Register a Professor
        [HttpPost("register/professor")]
        public async Task<ActionResult> RegisterProfessor(RegisterDto registerDto)
        {
            if (await _context.Professors.AnyAsync(x => x.Email == registerDto.Email))
                return BadRequest("Email already exists");

            var professor = new Professor
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Password = registerDto.Password, // Consider hashing the password before storing
                ProfilePictureUrl = registerDto.ProfilePictureUrl,
                Subjects = registerDto.Subjects
            };

            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Registration successful" });
        }

        // Login a Professor
        [HttpPost("login/professor")]
        public async Task<ActionResult> LoginProfessor(LoginDto loginDto)
        {
            var professor = await _context.Professors.SingleOrDefaultAsync(x => x.Email == loginDto.Email);

            if (professor == null || professor.Password != loginDto.Password) // Consider hashing the password before comparing
                return Unauthorized("Invalid email or password");

            var token = _jwtGenerator.CreateToken(professor.Email, "Professor");

            return Ok(new { success = true, professor, token });
        }

        // Get a Specific Professor by Email
        [HttpGet("professor/{email}")]
        [Authorize]
        public async Task<ActionResult> GetProfessor(string email)
        {
            var professor = await _context.Professors.SingleOrDefaultAsync(x => x.Email == email);

            if (professor == null)
                return NotFound("Professor not found");

            return Ok(new { success = true, professor });
        }

        // Get All Professors
        [HttpGet("professors")]
        [Authorize]
        public async Task<ActionResult> GetProfessors()
        {
            var professors = await _context.Professors.ToListAsync();

            return Ok(new { success = true, professors });
        }
    }
}
