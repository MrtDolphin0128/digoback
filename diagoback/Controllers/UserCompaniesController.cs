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
    public class UserCompaniesController : ControllerBase
    {
        private readonly diagodbContext _context;

        public UserCompaniesController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/UserCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserCompanies>>> GetUserCompanies()
        {
            return await _context.UserCompanies.ToListAsync();
        }

        // GET: api/UserCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserCompanies>> GetUserCompanies(int id)
        {
            var userCompanies = await _context.UserCompanies.FindAsync(id);

            if (userCompanies == null)
            {
                return NotFound();
            }

            return userCompanies;
        }

        // PUT: api/UserCompanies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserCompanies(int id, UserCompanies userCompanies)
        {
            if (id != userCompanies.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userCompanies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCompaniesExists(id))
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

        // POST: api/UserCompanies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserCompanies>> PostUserCompanies(UserCompanies userCompanies)
        {
            _context.UserCompanies.Add(userCompanies);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserCompaniesExists(userCompanies.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserCompanies", new { id = userCompanies.UserId }, userCompanies);
        }

        // DELETE: api/UserCompanies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserCompanies>> DeleteUserCompanies(int id)
        {
            var userCompanies = await _context.UserCompanies.FindAsync(id);
            if (userCompanies == null)
            {
                return NotFound();
            }

            _context.UserCompanies.Remove(userCompanies);
            await _context.SaveChangesAsync();

            return userCompanies;
        }

        private bool UserCompaniesExists(int id)
        {
            return _context.UserCompanies.Any(e => e.UserId == id);
        }
    }
}
