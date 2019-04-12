using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustMyResumeApi.Data;
using JustMyResumeApi.Models;

namespace JustMyResumeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationItemsController : ControllerBase
    {
        private readonly JustMyResumeContext _context;

        public EducationItemsController(JustMyResumeContext context)
        {
            _context = context;
        }

        // GET: api/EducationItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationItem>>> GetEducationItems()
        {
            return await _context.EducationItems.ToListAsync();
        }

        [HttpGet("Users/{id}")]
        public async Task<ActionResult<IEnumerable<EducationItem>>> GetUserEducationItems(long id)
        {
            return await _context.EducationItems.Where(item => item.UserId == id).OrderBy(item => item.SortOrder).ToListAsync();
        }

        // GET: api/EducationItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EducationItem>> GetEducationItem(long id)
        {
            var educationItem = await _context.EducationItems.FindAsync(id);

            if (educationItem == null)
            {
                return NotFound();
            }

            return educationItem;
        }

        // PUT: api/EducationItems/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutEducationItem(long id, EducationItem educationItem)
        {
            if (id != educationItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationItemExists(id))
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

        // POST: api/EducationItems
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<EducationItem>> PostEducationItem(EducationItem educationItem)
        {
            _context.EducationItems.Add(educationItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationItem", new { id = educationItem.Id }, educationItem);
        }

        // DELETE: api/EducationItems/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EducationItem>> DeleteEducationItem(long id)
        {
            var educationItem = await _context.EducationItems.FindAsync(id);
            if (educationItem == null)
            {
                return NotFound();
            }

            _context.EducationItems.Remove(educationItem);
            await _context.SaveChangesAsync();

            return educationItem;
        }

        private bool EducationItemExists(long id)
        {
            return _context.EducationItems.Any(e => e.Id == id);
        }
    }
}
