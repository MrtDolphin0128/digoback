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
    public class DashboardsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public DashboardsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/Dashboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dashboards>>> GetDashboards()
        {
            return await _context.Dashboards.ToListAsync();
        }

        // GET: api/Dashboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dashboards>> GetDashboards(int id)
        {
            var dashboards = await _context.Dashboards.FindAsync(id);

            if (dashboards == null)
            {
                return NotFound();
            }

            return dashboards;
        }

        // PUT: api/Dashboards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDashboards(int id, Dashboards dashboards)
        {
            if (id != dashboards.Id)
            {
                return BadRequest();
            }

            _context.Entry(dashboards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardsExists(id))
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

        // POST: api/Dashboards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dashboards>> PostDashboards(Dashboards dashboards)
        {
            _context.Dashboards.Add(dashboards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDashboards", new { id = dashboards.Id }, dashboards);
        }

        // DELETE: api/Dashboards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dashboards>> DeleteDashboards(int id)
        {
            var dashboards = await _context.Dashboards.FindAsync(id);
            if (dashboards == null)
            {
                return NotFound();
            }

            _context.Dashboards.Remove(dashboards);
            await _context.SaveChangesAsync();

            return dashboards;
        }

        private bool DashboardsExists(int id)
        {
            return _context.Dashboards.Any(e => e.Id == id);
        }
    }
}
