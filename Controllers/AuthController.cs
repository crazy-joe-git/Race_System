using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System.Data;
using Race_System.Models;

namespace Race_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Race_SystemDbContext _context;

        public AuthController(Race_SystemDbContext context)
        {
            _context = context;
        }

        // DTO for Register Request
        public class RegisterDto
        {
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public DateTime DateOfBirth { get; set; }
            public string Email { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Role { get; set; } = "Participant"; // Default to Participant
        }

        // DTO for Login Request
        public class LoginDto
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            // Check if email already exists
            if (await _context.Participants.AnyAsync(p => p.Email == dto.Email))
            {
                return BadRequest(new { message = "Email is already registered." });
            }

            // Create new participant matching Part 1 ERD
            var participant = new Participant
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                Phone = dto.Phone,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // Secure hash
                Role = dto.Role
            };

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registration successful!", participantID = participant.ParticipantID });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var participant = await _context.Participants.FirstOrDefaultAsync(p => p.Email == dto.Email);

            if (participant == null || string.IsNullOrEmpty(participant.PasswordHash) || !BCrypt.Net.BCrypt.Verify(dto.Password, participant.PasswordHash))
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(new { message = "Login successful!", participantID = participant.ParticipantID, role = participant.Role, name = $"{participant.FirstName} {participant.LastName}" });
        }
    }
}