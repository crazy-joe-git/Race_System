using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System.Data;
using Race_System.Models;

namespace Race_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventRacesController : ControllerBase
    {
        private readonly Race_SystemDbContext _context;

        public EventRacesController(Race_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/eventraces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventRace>>> GetEventRaces()
        {
            return await _context.EventRaces.ToListAsync();
        }

        // GET: api/eventraces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventRace>> GetEventRace(int id)
        {
            var eventRace = await _context.EventRaces.FindAsync(id);
            if (eventRace == null)
            {
                return NotFound(new { message = $"EventRace with ID {id} not found." });
            }
            return eventRace;
        }
    }
}