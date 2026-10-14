using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System.Data;
using Race_System.Models;

namespace Race_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly Race_SystemDbContext _context;

        public RegistrationsController(Race_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/registrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            return await _context.Registrations.ToListAsync();
        }

        // GET: api/registrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound(new { message = $"Registration with ID {id} not found." });
            }
            return registration;
        }

        // POST: api/registrations
        [HttpPost]
        public async Task<ActionResult<Registration>> CreateRegistration([FromBody] Registration registration)
        {
            registration.Reg_Date = DateTime.Now;
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistration), new { id = registration.RegistrationID }, registration);
        }
    }
}