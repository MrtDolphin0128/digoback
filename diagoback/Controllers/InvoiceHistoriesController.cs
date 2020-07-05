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
    public class InvoiceHistoriesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public InvoiceHistoriesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceHistories>>> GetInvoiceHistories()
        {
            return await _context.InvoiceHistories.ToListAsync();
        }

        // GET: api/InvoiceHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceHistories>> GetInvoiceHistories(int id)
        {
            var invoiceHistories = await _context.InvoiceHistories.FindAsync(id);

            if (invoiceHistories == null)
            {
                return NotFound();
            }

            return invoiceHistories;
        }

        // PUT: api/InvoiceHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceHistories(int id, InvoiceHistories invoiceHistories)
        {
            if (id != invoiceHistories.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceHistories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceHistoriesExists(id))
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

        // POST: api/InvoiceHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InvoiceHistories>> PostInvoiceHistories(InvoiceHistories invoiceHistories)
        {
            _context.InvoiceHistories.Add(invoiceHistories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceHistories", new { id = invoiceHistories.Id }, invoiceHistories);
        }

        // DELETE: api/InvoiceHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceHistories>> DeleteInvoiceHistories(int id)
        {
            var invoiceHistories = await _context.InvoiceHistories.FindAsync(id);
            if (invoiceHistories == null)
            {
                return NotFound();
            }

            _context.InvoiceHistories.Remove(invoiceHistories);
            await _context.SaveChangesAsync();

            return invoiceHistories;
        }

        private bool InvoiceHistoriesExists(int id)
        {
            return _context.InvoiceHistories.Any(e => e.Id == id);
        }
    }
}
