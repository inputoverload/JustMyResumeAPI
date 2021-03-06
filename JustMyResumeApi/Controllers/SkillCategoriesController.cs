﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustMyResumeApi.Data;
using JustMyResumeApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace JustMyResumeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private readonly JustMyResumeContext _context;

        public SkillCategoriesController(JustMyResumeContext context)
        {
            _context = context;
        }

        // GET: api/SkillCategories
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<SkillCategory>>> GetSkillCategories()
        {
            return await _context.SkillCategories.OrderBy(item => item.SortOrder).ToListAsync();
        }

        // GET: api/SkillCategories/5
        [HttpGet("{id}"), Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SkillCategory>> GetSkillCategory(long id)
        {
            var skillCategory = await _context.SkillCategories.FindAsync(id);

            if (skillCategory == null)
            {
                return NotFound();
            }

            return skillCategory;
        }

        // PUT: api/SkillCategories/5
        [HttpPut("{id}"), Authorize]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutSkillCategory(long id, SkillCategory skillCategory)
        {
            if (id != skillCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(skillCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillCategoryExists(id))
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

        // POST: api/SkillCategories
        [HttpPost, Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<SkillCategory>> PostSkillCategory(SkillCategory skillCategory)
        {
            _context.SkillCategories.Add(skillCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkillCategory", new { id = skillCategory.Id }, skillCategory);
        }

        // DELETE: api/SkillCategories/5
        [HttpDelete("{id}"), Authorize]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SkillCategory>> DeleteSkillCategory(long id)
        {
            var skillCategory = await _context.SkillCategories.FindAsync(id);
            if (skillCategory == null)
            {
                return NotFound();
            }

            _context.SkillCategories.Remove(skillCategory);
            await _context.SaveChangesAsync();

            return skillCategory;
        }

        private bool SkillCategoryExists(long id)
        {
            return _context.SkillCategories.Any(e => e.Id == id);
        }
    }
}
