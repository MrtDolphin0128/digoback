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
    public class NotificationsController : ControllerBase
    {
        private readonly diagodbContext _context;

        public NotificationsController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/Notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notifications>>> GetNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        // GET: api/Notifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notifications>> GetNotifications(string id)
        {
            var notifications = await _context.Notifications.FindAsync(id);

            if (notifications == null)
            {
                return NotFound();
            }

            return notifications;
        }

        // PUT: api/Notifications/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotifications(string id, Notifications notifications)
        {
            if (id != notifications.Id)
            {
                return BadRequest();
            }

            _context.Entry(notifications).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotificationsExists(id))
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

        // POST: api/Notifications
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Notifications>> PostNotifications(Notifications notifications)
        {
            _context.Notifications.Add(notifications);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NotificationsExists(notifications.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNotifications", new { id = notifications.Id }, notifications);
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notifications>> DeleteNotifications(string id)
        {
            var notifications = await _context.Notifications.FindAsync(id);
            if (notifications == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notifications);
            await _context.SaveChangesAsync();

            return notifications;
        }

        private bool NotificationsExists(string id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
