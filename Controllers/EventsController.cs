using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System.Data;
using Race_System.Models;

namespace Race_System.Controllers
{
    // [ApiController] and [Route] turn this class into a RESTful API endpoint
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly Race_SystemDbContext _context;

        
        public EventsController(Race_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var raceEvent = await _context.Events.FindAsync(id);

            // If the event doesn't exist, return a 404 Not Found response
            if (raceEvent == null)
            {
                return NotFound(new { message = $"Event with ID {id} not found." });
            }

            return raceEvent;
        }

        // GET: api/events/101/categories
        [HttpGet("{eventId}/categories")]
        public async Task<ActionResult<IEnumerable<RaceCategory>>> GetEventCategories(int eventId)
        {
            var categoryIds = await _context.EventRaces
                .Where(er => er.EventID == eventId)
                .Select(er => er.CategoryID)
                .ToListAsync();

            var categories = await _context.Categories
                .Where(c => categoryIds.Contains(c.CategoryID))
                .ToListAsync();

            return categories;
        }
    }
}