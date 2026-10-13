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

        // Inject our database context so the controller can talk to SSMS
        public EventsController(Race_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/events
        // Retrieves all running/cycling events from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            // Fetch all events from the Event table asynchronously
            return await _context.Events.ToListAsync();
        }

        // GET: api/events/5
        // Retrieves a single event by its unique ID
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
        // Retrieves all race categories linked to a specific event through EventRace
        //Data contracts or related helper queries can go here
        [HttpGet("{eventId}/categories")]
        public async Task<ActionResult<IEnumerable<RaceCategory>>> GetEventCategories(int eventId)
        {
            // Find category IDs associated with this event in the EventRace table
            var categoryIds = await _context.EventRaces
                .Where(er => er.EventID == eventId)
                .Select(er => er.CategoryID)
                .ToListAsync();

            // Fetch the actual category details
            var categories = await _context.Categories
                .Where(c => categoryIds.Contains(c.CategoryID))
                .ToListAsync();

            return categories;
        }
    }
}