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
    public class UserPermissionsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public UserPermissionsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/UserPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPermissions>>> GetUserPermissions()
        {
            return await _context.UserPermissions.ToListAsync();
        }

        // GET: api/UserPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPermissions>> GetUserPermissions(int id)
        {
            var userPermissions = await _context.UserPermissions.FindAsync(id);

            if (userPermissions == null)
            {
                return NotFound();
            }

            return userPermissions;
        }

        // PUT: api/UserPermissions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPermissions(int id, UserPermissions userPermissions)
        {
            if (id != userPermissions.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userPermissions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPermissionsExists(id))
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

        // POST: api/UserPermissions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserPermissions>> PostUserPermissions(UserPermissions userPermissions)
        {
            _context.UserPermissions.Add(userPermissions);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserPermissionsExists(userPermissions.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserPermissions", new { id = userPermissions.UserId }, userPermissions);
        }

        // DELETE: api/UserPermissions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserPermissions>> DeleteUserPermissions(int id)
        {
            var userPermissions = await _context.UserPermissions.FindAsync(id);
            if (userPermissions == null)
            {
                return NotFound();
            }

            _context.UserPermissions.Remove(userPermissions);
            await _context.SaveChangesAsync();

            return userPermissions;
        }

        private bool UserPermissionsExists(int id)
        {
            return _context.UserPermissions.Any(e => e.UserId == id);
        }
    }
}
