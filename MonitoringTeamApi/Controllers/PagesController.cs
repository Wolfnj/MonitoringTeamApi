using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringTeamApi.Models;

namespace MonitoringTeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public PagesController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Pages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pages>>> GetPages()
        {
            return await _context.Pages.ToListAsync();
        }

        // GET: api/Pages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pages>> GetPages(int id)
        {
            var pages = await _context.Pages.FindAsync(id);

            if (pages == null)
            {
                return NotFound();
            }

            return pages;
        }

        // PUT: api/Pages/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPages(int id, Pages pages)
        {
            if (id != pages.Id)
            {
                return BadRequest();
            }

            _context.Entry(pages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagesExists(id))
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

        // POST: api/Pages
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pages>> PostPages(Pages pages)
        {
            _context.Pages.Add(pages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPages", new { id = pages.Id }, pages);
        }

        // DELETE: api/Pages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pages>> DeletePages(int id)
        {
            var pages = await _context.Pages.FindAsync(id);
            if (pages == null)
            {
                return NotFound();
            }

            _context.Pages.Remove(pages);
            await _context.SaveChangesAsync();

            return pages;
        }

        private bool PagesExists(int id)
        {
            return _context.Pages.Any(e => e.Id == id);
        }
    }
}
