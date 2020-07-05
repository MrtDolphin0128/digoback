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
    public class MediaController : ControllerBase
    {
        private readonly diagodbContext _context;

        public MediaController(diagodbContext context)
        {
            _context = context;
        }

        // GET: api/Media
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Media>>> GetMedia()
        {
            return await _context.Media.ToListAsync();
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Media>> GetMedia(int id)
        {
            var media = await _context.Media.FindAsync(id);

            if (media == null)
            {
                return NotFound();
            }

            return media;
        }

        // PUT: api/Media/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia(int id, Media media)
        {
            if (id != media.Id)
            {
                return BadRequest();
            }

            _context.Entry(media).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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

        // POST: api/Media
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Media>> PostMedia(Media media)
        {
            _context.Media.Add(media);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedia", new { id = media.Id }, media);
        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Media>> DeleteMedia(int id)
        {
            var media = await _context.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            _context.Media.Remove(media);
            await _context.SaveChangesAsync();

            return media;
        }

        private bool MediaExists(int id)
        {
            return _context.Media.Any(e => e.Id == id);
        }
    }
}
