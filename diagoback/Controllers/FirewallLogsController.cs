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
    public class FirewallLogsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public FirewallLogsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/FirewallLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FirewallLogs>>> GetFirewallLogs()
        {
            return await _context.FirewallLogs.ToListAsync();
        }

        // GET: api/FirewallLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FirewallLogs>> GetFirewallLogs(int id)
        {
            var firewallLogs = await _context.FirewallLogs.FindAsync(id);

            if (firewallLogs == null)
            {
                return NotFound();
            }

            return firewallLogs;
        }

        // PUT: api/FirewallLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirewallLogs(int id, FirewallLogs firewallLogs)
        {
            if (id != firewallLogs.Id)
            {
                return BadRequest();
            }

            _context.Entry(firewallLogs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirewallLogsExists(id))
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

        // POST: api/FirewallLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FirewallLogs>> PostFirewallLogs(FirewallLogs firewallLogs)
        {
            _context.FirewallLogs.Add(firewallLogs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirewallLogs", new { id = firewallLogs.Id }, firewallLogs);
        }

        // DELETE: api/FirewallLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FirewallLogs>> DeleteFirewallLogs(int id)
        {
            var firewallLogs = await _context.FirewallLogs.FindAsync(id);
            if (firewallLogs == null)
            {
                return NotFound();
            }

            _context.FirewallLogs.Remove(firewallLogs);
            await _context.SaveChangesAsync();

            return firewallLogs;
        }

        private bool FirewallLogsExists(int id)
        {
            return _context.FirewallLogs.Any(e => e.Id == id);
        }
    }
}
