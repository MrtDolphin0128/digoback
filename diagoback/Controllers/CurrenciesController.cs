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
    public class CurrenciesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public CurrenciesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currencies>>> GetCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currencies>> GetCurrencies(int id)
        {
            var currencies = await _context.Currencies.FindAsync(id);

            if (currencies == null)
            {
                return NotFound();
            }

            return currencies;
        }

        // PUT: api/Currencies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrencies(int id, Currencies currencies)
        {
            if (id != currencies.Id)
            {
                return BadRequest();
            }

            _context.Entry(currencies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrenciesExists(id))
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

        // POST: api/Currencies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Currencies>> PostCurrencies(Currencies currencies)
        {
            _context.Currencies.Add(currencies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrencies", new { id = currencies.Id }, currencies);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Currencies>> DeleteCurrencies(int id)
        {
            var currencies = await _context.Currencies.FindAsync(id);
            if (currencies == null)
            {
                return NotFound();
            }

            _context.Currencies.Remove(currencies);
            await _context.SaveChangesAsync();

            return currencies;
        }

        private bool CurrenciesExists(int id)
        {
            return _context.Currencies.Any(e => e.Id == id);
        }
    }
}
