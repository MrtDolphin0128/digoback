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
    public class BillHistoriesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public BillHistoriesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/BillHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillHistories>>> GetBillHistories()
        {
            return await _context.BillHistories.ToListAsync();
        }

        // GET: api/BillHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillHistories>> GetBillHistories(int id)
        {
            var billHistories = await _context.BillHistories.FindAsync(id);

            if (billHistories == null)
            {
                return NotFound();
            }

            return billHistories;
        }

        // PUT: api/BillHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillHistories(int id, BillHistories billHistories)
        {
            if (id != billHistories.Id)
            {
                return BadRequest();
            }

            _context.Entry(billHistories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillHistoriesExists(id))
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

        // POST: api/BillHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BillHistories>> PostBillHistories(BillHistories billHistories)
        {
            _context.BillHistories.Add(billHistories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillHistories", new { id = billHistories.Id }, billHistories);
        }

        // DELETE: api/BillHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillHistories>> DeleteBillHistories(int id)
        {
            var billHistories = await _context.BillHistories.FindAsync(id);
            if (billHistories == null)
            {
                return NotFound();
            }

            _context.BillHistories.Remove(billHistories);
            await _context.SaveChangesAsync();

            return billHistories;
        }

        private bool BillHistoriesExists(int id)
        {
            return _context.BillHistories.Any(e => e.Id == id);
        }
    }
}
