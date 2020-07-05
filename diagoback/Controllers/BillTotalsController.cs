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
    public class BillTotalsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public BillTotalsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/BillTotals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillTotals>>> GetBillTotals()
        {
            return await _context.BillTotals.ToListAsync();
        }

        // GET: api/BillTotals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillTotals>> GetBillTotals(int id)
        {
            var billTotals = await _context.BillTotals.FindAsync(id);

            if (billTotals == null)
            {
                return NotFound();
            }

            return billTotals;
        }

        // PUT: api/BillTotals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillTotals(int id, BillTotals billTotals)
        {
            if (id != billTotals.Id)
            {
                return BadRequest();
            }

            _context.Entry(billTotals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillTotalsExists(id))
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

        // POST: api/BillTotals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillTotals>> PostBillTotals(BillTotals billTotals)
        {
            _context.BillTotals.Add(billTotals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillTotals", new { id = billTotals.Id }, billTotals);
        }

        // DELETE: api/BillTotals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillTotals>> DeleteBillTotals(int id)
        {
            var billTotals = await _context.BillTotals.FindAsync(id);
            if (billTotals == null)
            {
                return NotFound();
            }

            _context.BillTotals.Remove(billTotals);
            await _context.SaveChangesAsync();

            return billTotals;
        }

        private bool BillTotalsExists(int id)
        {
            return _context.BillTotals.Any(e => e.Id == id);
        }
    }
}
