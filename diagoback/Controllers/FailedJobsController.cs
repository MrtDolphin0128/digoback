using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using diagoback.Models;
using Microsoft.AspNetCore.Authorization;

namespace diagoback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FailedJobsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public FailedJobsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/FailedJobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FailedJobs>>> GetFailedJobs()
        {
            return await _context.FailedJobs.ToListAsync();
        }

        // GET: api/FailedJobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FailedJobs>> GetFailedJobs(long id)
        {
            var failedJobs = await _context.FailedJobs.FindAsync(id);

            if (failedJobs == null)
            {
                return NotFound();
            }

            return failedJobs;
        }

        // PUT: api/FailedJobs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFailedJobs(long id, FailedJobs failedJobs)
        {
            if (id != failedJobs.Id)
            {
                return BadRequest();
            }

            _context.Entry(failedJobs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FailedJobsExists(id))
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

        // POST: api/FailedJobs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FailedJobs>> PostFailedJobs(FailedJobs failedJobs)
        {
            _context.FailedJobs.Add(failedJobs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFailedJobs", new { id = failedJobs.Id }, failedJobs);
        }

        // DELETE: api/FailedJobs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FailedJobs>> DeleteFailedJobs(long id)
        {
            var failedJobs = await _context.FailedJobs.FindAsync(id);
            if (failedJobs == null)
            {
                return NotFound();
            }

            _context.FailedJobs.Remove(failedJobs);
            await _context.SaveChangesAsync();

            return failedJobs;
        }

        private bool FailedJobsExists(long id)
        {
            return _context.FailedJobs.Any(e => e.Id == id);
        }
    }
}
