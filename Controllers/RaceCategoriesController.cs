using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System.Data;
using Race_System.Models;

namespace Race_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceCategoriesController : ControllerBase
    {
        private readonly Race_SystemDbContext _context;

        public RaceCategoriesController(Race_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/racecategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceCategory>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/racecategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RaceCategory>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new { message = $"Category with ID {id} not found." });
            }
            return category;
        }
    }
}