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
    public class EmailTemplatesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public EmailTemplatesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/EmailTemplates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmailTemplates>>> GetEmailTemplates()
        {
            return await _context.EmailTemplates.ToListAsync();
        }

        // GET: api/EmailTemplates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmailTemplates>> GetEmailTemplates(int id)
        {
            var emailTemplates = await _context.EmailTemplates.FindAsync(id);

            if (emailTemplates == null)
            {
                return NotFound();
            }

            return emailTemplates;
        }

        // PUT: api/EmailTemplates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmailTemplates(int id, EmailTemplates emailTemplates)
        {
            if (id != emailTemplates.Id)
            {
                return BadRequest();
            }

            _context.Entry(emailTemplates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailTemplatesExists(id))
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

        // POST: api/EmailTemplates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmailTemplates>> PostEmailTemplates(EmailTemplates emailTemplates)
        {
            _context.EmailTemplates.Add(emailTemplates);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmailTemplates", new { id = emailTemplates.Id }, emailTemplates);
        }

        // DELETE: api/EmailTemplates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailTemplates>> DeleteEmailTemplates(int id)
        {
            var emailTemplates = await _context.EmailTemplates.FindAsync(id);
            if (emailTemplates == null)
            {
                return NotFound();
            }

            _context.EmailTemplates.Remove(emailTemplates);
            await _context.SaveChangesAsync();

            return emailTemplates;
        }

        private bool EmailTemplatesExists(int id)
        {
            return _context.EmailTemplates.Any(e => e.Id == id);
        }
    }
}
