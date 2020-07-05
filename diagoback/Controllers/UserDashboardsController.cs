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
    public class UserDashboardsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public UserDashboardsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/UserDashboards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDashboards>>> GetUserDashboards()
        {
            return await _context.UserDashboards.ToListAsync();
        }

        // GET: api/UserDashboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDashboards>> GetUserDashboards(int id)
        {
            var userDashboards = await _context.UserDashboards.FindAsync(id);

            if (userDashboards == null)
            {
                return NotFound();
            }

            return userDashboards;
        }

        // PUT: api/UserDashboards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserDashboards(int id, UserDashboards userDashboards)
        {
            if (id != userDashboards.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userDashboards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDashboardsExists(id))
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

        // POST: api/UserDashboards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserDashboards>> PostUserDashboards(UserDashboards userDashboards)
        {
            _context.UserDashboards.Add(userDashboards);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserDashboardsExists(userDashboards.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserDashboards", new { id = userDashboards.UserId }, userDashboards);
        }

        // DELETE: api/UserDashboards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDashboards>> DeleteUserDashboards(int id)
        {
            var userDashboards = await _context.UserDashboards.FindAsync(id);
            if (userDashboards == null)
            {
                return NotFound();
            }

            _context.UserDashboards.Remove(userDashboards);
            await _context.SaveChangesAsync();

            return userDashboards;
        }

        private bool UserDashboardsExists(int id)
        {
            return _context.UserDashboards.Any(e => e.UserId == id);
        }
    }
}
