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
    public class BillItemTaxesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public BillItemTaxesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/BillItemTaxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillItemTaxes>>> GetBillItemTaxes()
        {
            return await _context.BillItemTaxes.ToListAsync();
        }

        // GET: api/BillItemTaxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillItemTaxes>> GetBillItemTaxes(int id)
        {
            var billItemTaxes = await _context.BillItemTaxes.FindAsync(id);

            if (billItemTaxes == null)
            {
                return NotFound();
            }

            return billItemTaxes;
        }

        // PUT: api/BillItemTaxes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillItemTaxes(int id, BillItemTaxes billItemTaxes)
        {
            if (id != billItemTaxes.Id)
            {
                return BadRequest();
            }

            _context.Entry(billItemTaxes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillItemTaxesExists(id))
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

        // POST: api/BillItemTaxes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillItemTaxes>> PostBillItemTaxes(BillItemTaxes billItemTaxes)
        {
            _context.BillItemTaxes.Add(billItemTaxes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillItemTaxes", new { id = billItemTaxes.Id }, billItemTaxes);
        }

        // DELETE: api/BillItemTaxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillItemTaxes>> DeleteBillItemTaxes(int id)
        {
            var billItemTaxes = await _context.BillItemTaxes.FindAsync(id);
            if (billItemTaxes == null)
            {
                return NotFound();
            }

            _context.BillItemTaxes.Remove(billItemTaxes);
            await _context.SaveChangesAsync();

            return billItemTaxes;
        }

        private bool BillItemTaxesExists(int id)
        {
            return _context.BillItemTaxes.Any(e => e.Id == id);
        }
    }
}
