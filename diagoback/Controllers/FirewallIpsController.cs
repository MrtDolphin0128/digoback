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
    public class FirewallIpsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public FirewallIpsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/FirewallIps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FirewallIps>>> GetFirewallIps()
        {
            return await _context.FirewallIps.ToListAsync();
        }

        // GET: api/FirewallIps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FirewallIps>> GetFirewallIps(int id)
        {
            var firewallIps = await _context.FirewallIps.FindAsync(id);

            if (firewallIps == null)
            {
                return NotFound();
            }

            return firewallIps;
        }

        // PUT: api/FirewallIps/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirewallIps(int id, FirewallIps firewallIps)
        {
            if (id != firewallIps.Id)
            {
                return BadRequest();
            }

            _context.Entry(firewallIps).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirewallIpsExists(id))
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

        // POST: api/FirewallIps
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FirewallIps>> PostFirewallIps(FirewallIps firewallIps)
        {
            _context.FirewallIps.Add(firewallIps);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirewallIps", new { id = firewallIps.Id }, firewallIps);
        }

        // DELETE: api/FirewallIps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FirewallIps>> DeleteFirewallIps(int id)
        {
            var firewallIps = await _context.FirewallIps.FindAsync(id);
            if (firewallIps == null)
            {
                return NotFound();
            }

            _context.FirewallIps.Remove(firewallIps);
            await _context.SaveChangesAsync();

            return firewallIps;
        }

        private bool FirewallIpsExists(int id)
        {
            return _context.FirewallIps.Any(e => e.Id == id);
        }
    }
}
