using dotInstrukcije.API.Data;
using dotInstrukcije.API.Dtos;
using dotInstrukcije.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace dotInstrukcije.API.Controllers
{
    [ApiController]
    [Authorize]
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SubjectController(AppDbContext context)
        {
            _context = context;
        }

        // Create a Subject
        [HttpPost("subject")]
        public async Task<ActionResult> CreateSubject(SubjectDto subjectDto)
        {
            if (await _context.Subjects.AnyAsync(x => x.Title == subjectDto.Title))
                return BadRequest(new { success = false, message = "Title already exists" });

            var subject = new Subject
            {
                Title = subjectDto.Title,
                Url = subjectDto.Url,
                Description = subjectDto.Description
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Subject creation successful" });
        }

        // Get a Specific Subject by Url
        [HttpGet("subject/{url}")]
        public async Task<ActionResult> GetSubject(string url)
        {
            var subject = await _context.Subjects.SingleOrDefaultAsync(x => x.Url == url);

            if (subject == null)
                return NotFound(new { success = false, message = "Subject not found" });

            return Ok(new { success = true, subject });
        }

        // Get All Subjects
        [HttpGet("subjects")]
        public async Task<ActionResult> GetSubjects()
        {
            var subjects = await _context.Subjects.ToListAsync();

            return Ok(new { success = true, subjects });
        }
    }
}
