using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeManagementService.Data;
using TimeManagementService.Models;

namespace TimeManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TimeEntriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeEntry>>> GetTimeEntries()
        {
            return await _context.TimeEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeEntry>> GetTimeEntry(int id)
        {
            var timeEntry = await _context.TimeEntries.FindAsync(id);

            if (timeEntry == null)
            {
                return NotFound();
            }

            return timeEntry;
        }

        [HttpPost]
        public async Task<ActionResult<TimeEntry>> PostTimeEntry(TimeEntry timeEntry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Setting CreatedAt to current time
            timeEntry.CreatedAt = DateTime.UtcNow;

            _context.TimeEntries.Add(timeEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTimeEntry), new { id = timeEntry.Id }, timeEntry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeEntry(int id, TimeEntry timeEntry)
        {
            if (id != timeEntry.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            timeEntry.UpdatedAt = DateTime.UtcNow;

            _context.Entry(timeEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeEntry(int id)
        {
            var timeEntry = await _context.TimeEntries.FindAsync(id);
            if (timeEntry == null)
            {
                return NotFound();
            }

            _context.TimeEntries.Remove(timeEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TimeEntryExists(int id)
        {
            return _context.TimeEntries.Any(e => e.Id == id);
        }
    }
}