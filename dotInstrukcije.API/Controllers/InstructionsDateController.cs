using dotInstrukcije.API.Data;
using dotInstrukcije.API.Dtos;
using dotInstrukcije.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotInstrukcije.API.Controllers
{
    [ApiController]
    [Authorize]
    public class InstructionsDateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InstructionsDateController(AppDbContext context)
        {
            _context = context;
        }

        // Schedule an Instruction Session
        [HttpPost("instructions")]
        public async Task<ActionResult> ScheduleInstructionSession(InstructionSessionDto instructionSessionDto)
        {
            var professor = await _context.Professors.FindAsync(instructionSessionDto.ProfessorId);

            if (professor == null)
                return NotFound(new { success = false, message = "Professor not found" });

            var instructionSession = new InstructionsDate
            {
                DateTime = instructionSessionDto.Date,
                ProfessorId = instructionSessionDto.ProfessorId
            };

            _context.InstructionsDates.Add(instructionSession);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Instruction session scheduled successfully" });
        }
    }
}
