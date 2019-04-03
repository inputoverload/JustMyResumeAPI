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
    public class TechSkillsController : ControllerBase
    {
        private readonly JustMyResumeContext _context;

        public TechSkillsController(JustMyResumeContext context)
        {
            _context = context;
        }

        // GET: api/TechSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechSkill>>> GetTechSkills()
        {
            return await _context.TechSkills.ToListAsync();
        }

        [HttpGet("Users/{id}")]
        public async Task<ActionResult<IEnumerable<TechSkill>>> GetUserTechSkills(long id)
        {
            return await _context.TechSkills.Where(item => item.UserId == id).OrderBy(item => item.SortOrder).ToListAsync();
        }

        // GET: api/TechSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TechSkill>> GetTechSkill(long id)
        {
            var techSkill = await _context.TechSkills.FindAsync(id);

            if (techSkill == null)
            {
                return NotFound();
            }

            return techSkill;
        }

        // PUT: api/TechSkills/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechSkill(long id, TechSkill techSkill)
        {
            if (id != techSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(techSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechSkillExists(id))
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

        // POST: api/TechSkills
        [HttpPost]
        public async Task<ActionResult<TechSkill>> PostTechSkill(TechSkill techSkill)
        {
            _context.TechSkills.Add(techSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechSkill", new { id = techSkill.Id }, techSkill);
        }

        // DELETE: api/TechSkills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TechSkill>> DeleteTechSkill(long id)
        {
            var techSkill = await _context.TechSkills.FindAsync(id);
            if (techSkill == null)
            {
                return NotFound();
            }

            _context.TechSkills.Remove(techSkill);
            await _context.SaveChangesAsync();

            return techSkill;
        }

        private bool TechSkillExists(long id)
        {
            return _context.TechSkills.Any(e => e.Id == id);
        }
    }
}
