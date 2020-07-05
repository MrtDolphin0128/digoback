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
    public class ModuleHistoriesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public ModuleHistoriesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/ModuleHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleHistories>>> GetModuleHistories()
        {
            return await _context.ModuleHistories.ToListAsync();
        }

        // GET: api/ModuleHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleHistories>> GetModuleHistories(int id)
        {
            var moduleHistories = await _context.ModuleHistories.FindAsync(id);

            if (moduleHistories == null)
            {
                return NotFound();
            }

            return moduleHistories;
        }

        // PUT: api/ModuleHistories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModuleHistories(int id, ModuleHistories moduleHistories)
        {
            if (id != moduleHistories.Id)
            {
                return BadRequest();
            }

            _context.Entry(moduleHistories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleHistoriesExists(id))
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

        // POST: api/ModuleHistories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ModuleHistories>> PostModuleHistories(ModuleHistories moduleHistories)
        {
            _context.ModuleHistories.Add(moduleHistories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModuleHistories", new { id = moduleHistories.Id }, moduleHistories);
        }

        // DELETE: api/ModuleHistories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ModuleHistories>> DeleteModuleHistories(int id)
        {
            var moduleHistories = await _context.ModuleHistories.FindAsync(id);
            if (moduleHistories == null)
            {
                return NotFound();
            }

            _context.ModuleHistories.Remove(moduleHistories);
            await _context.SaveChangesAsync();

            return moduleHistories;
        }

        private bool ModuleHistoriesExists(int id)
        {
            return _context.ModuleHistories.Any(e => e.Id == id);
        }
    }
}
