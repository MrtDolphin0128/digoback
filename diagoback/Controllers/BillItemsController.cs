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
    public class BillItemsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public BillItemsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/BillItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillItems>>> GetBillItems()
        {
            return await _context.BillItems.ToListAsync();
        }

        // GET: api/BillItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillItems>> GetBillItems(int id)
        {
            var billItems = await _context.BillItems.FindAsync(id);

            if (billItems == null)
            {
                return NotFound();
            }

            return billItems;
        }

        // PUT: api/BillItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillItems(int id, BillItems billItems)
        {
            if (id != billItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(billItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillItemsExists(id))
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

        // POST: api/BillItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillItems>> PostBillItems(BillItems billItems)
        {
            _context.BillItems.Add(billItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillItems", new { id = billItems.Id }, billItems);
        }

        // DELETE: api/BillItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillItems>> DeleteBillItems(int id)
        {
            var billItems = await _context.BillItems.FindAsync(id);
            if (billItems == null)
            {
                return NotFound();
            }

            _context.BillItems.Remove(billItems);
            await _context.SaveChangesAsync();

            return billItems;
        }

        private bool BillItemsExists(int id)
        {
            return _context.BillItems.Any(e => e.Id == id);
        }
    }
}
