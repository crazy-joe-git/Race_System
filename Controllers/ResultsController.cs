using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_System.Data;
using Race_System.Models;

namespace Race_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly Race_SystemDbContext _context;

        public ResultsController(Race_SystemDbContext context)
        {
            _context = context;
        }

        // GET: api/results
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Result>>> GetResults()
        {
            return await _context.Results.ToListAsync();
        }

        // GET: api/results/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Result>> GetResult(int id)
        {
            var result = await _context.Results.FindAsync(id);
            if (result == null)
            {
                return NotFound(new { message = $"Result with ID {id} not found." });
            }
            return result;
        }

        // POST: api/results
        [HttpPost]
        public async Task<ActionResult<Result>> CreateResult([FromBody] Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResult), new { id = result.ResultID }, result);
        }
    }
}