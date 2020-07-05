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
    public class MigrationsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public MigrationsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/Migrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Migrations>>> GetMigrations()
        {
            return await _context.Migrations.ToListAsync();
        }

        // GET: api/Migrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Migrations>> GetMigrations(int id)
        {
            var migrations = await _context.Migrations.FindAsync(id);

            if (migrations == null)
            {
                return NotFound();
            }

            return migrations;
        }

        // PUT: api/Migrations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMigrations(int id, Migrations migrations)
        {
            if (id != migrations.Id)
            {
                return BadRequest();
            }

            _context.Entry(migrations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MigrationsExists(id))
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

        // POST: api/Migrations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Migrations>> PostMigrations(Migrations migrations)
        {
            _context.Migrations.Add(migrations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMigrations", new { id = migrations.Id }, migrations);
        }

        // DELETE: api/Migrations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Migrations>> DeleteMigrations(int id)
        {
            var migrations = await _context.Migrations.FindAsync(id);
            if (migrations == null)
            {
                return NotFound();
            }

            _context.Migrations.Remove(migrations);
            await _context.SaveChangesAsync();

            return migrations;
        }

        private bool MigrationsExists(int id)
        {
            return _context.Migrations.Any(e => e.Id == id);
        }
    }
}
