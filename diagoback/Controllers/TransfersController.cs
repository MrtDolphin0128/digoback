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
    public class TransfersController : ControllerBase
    {
        private readonly diagodbContext _context;

        public TransfersController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/Transfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transfers>>> GetTransfers()
        {
            return await _context.Transfers.ToListAsync();
        }

        // GET: api/Transfers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transfers>> GetTransfers(int id)
        {
            var transfers = await _context.Transfers.FindAsync(id);

            if (transfers == null)
            {
                return NotFound();
            }

            return transfers;
        }

        // PUT: api/Transfers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransfers(int id, Transfers transfers)
        {
            if (id != transfers.Id)
            {
                return BadRequest();
            }

            _context.Entry(transfers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransfersExists(id))
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

        // POST: api/Transfers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transfers>> PostTransfers(Transfers transfers)
        {
            _context.Transfers.Add(transfers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransfers", new { id = transfers.Id }, transfers);
        }

        // DELETE: api/Transfers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transfers>> DeleteTransfers(int id)
        {
            var transfers = await _context.Transfers.FindAsync(id);
            if (transfers == null)
            {
                return NotFound();
            }

            _context.Transfers.Remove(transfers);
            await _context.SaveChangesAsync();

            return transfers;
        }

        private bool TransfersExists(int id)
        {
            return _context.Transfers.Any(e => e.Id == id);
        }
    }
}
