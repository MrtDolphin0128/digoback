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
    public class InvoiceTotalsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public InvoiceTotalsController(diagodbContext context)
        {
            _context = context;
        }
        // GET: api/InvoiceTotals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceTotals>>> GetInvoiceTotals()
        {
            return await _context.InvoiceTotals.ToListAsync();
        }

        // GET: api/InvoiceTotals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceTotals>> GetInvoiceTotals(int id)
        {
            var invoiceTotals = await _context.InvoiceTotals.FindAsync(id);

            if (invoiceTotals == null)
            {
                return NotFound();
            }

            return invoiceTotals;
        }

        // PUT: api/InvoiceTotals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceTotals(int id, InvoiceTotals invoiceTotals)
        {
            if (id != invoiceTotals.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceTotals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTotalsExists(id))
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

        // POST: api/InvoiceTotals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvoiceTotals>> PostInvoiceTotals(InvoiceTotals invoiceTotals)
        {
            _context.InvoiceTotals.Add(invoiceTotals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceTotals", new { id = invoiceTotals.Id }, invoiceTotals);
        }

        // DELETE: api/InvoiceTotals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceTotals>> DeleteInvoiceTotals(int id)
        {
            var invoiceTotals = await _context.InvoiceTotals.FindAsync(id);
            if (invoiceTotals == null)
            {
                return NotFound();
            }

            _context.InvoiceTotals.Remove(invoiceTotals);
            await _context.SaveChangesAsync();

            return invoiceTotals;
        }

        private bool InvoiceTotalsExists(int id)
        {
            return _context.InvoiceTotals.Any(e => e.Id == id);
        }
    }
}
