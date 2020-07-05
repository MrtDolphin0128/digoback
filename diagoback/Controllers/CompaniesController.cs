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
    public class CompaniesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public CompaniesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Companies>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Companies>> GetCompanies(int id)
        {
            var companies = await _context.Companies.FindAsync(id);

            if (companies == null)
            {
                return NotFound();
            }

            return companies;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanies(int id, Companies companies)
        {
            if (id != companies.Id)
            {
                return BadRequest();
            }

            _context.Entry(companies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompaniesExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompanies(Companies companies)
        {
            _context.Companies.Add(companies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanies", new { id = companies.Id }, companies);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Companies>> DeleteCompanies(int id)
        {
            var companies = await _context.Companies.FindAsync(id);
            if (companies == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(companies);
            await _context.SaveChangesAsync();

            return companies;
        }

        private bool CompaniesExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
