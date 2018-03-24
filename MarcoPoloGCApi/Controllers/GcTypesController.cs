using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarcoPoloGCApi.Models;

namespace MarcoPoloGCApi.Controllers
{
    [Produces("application/json")]
    [Route("api/GcTypes")]
    public class GcTypesController : Controller
    {
        private readonly MarcoPoloGCDBContext _context;

        public GcTypesController(MarcoPoloGCDBContext context)
        {
            _context = context;
        }

        // GET: api/GcTypes
        [HttpGet]
        public IEnumerable<Gctype> GetGctype()
        {
            return _context.Gctype;
        }

        // GET: api/GcTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGctype([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gctype = await _context.Gctype.SingleOrDefaultAsync(m => m.Id == id);

            if (gctype == null)
            {
                return NotFound();
            }

            return Ok(gctype);
        }

        // PUT: api/GcTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGctype([FromRoute] int id, [FromBody] Gctype gctype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gctype.Id)
            {
                return BadRequest();
            }

            _context.Entry(gctype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GctypeExists(id))
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

        // POST: api/GcTypes
        [HttpPost]
        public async Task<IActionResult> PostGctype([FromBody] Gctype gctype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Gctype.Add(gctype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGctype", new { id = gctype.Id }, gctype);
        }

        // DELETE: api/GcTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGctype([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gctype = await _context.Gctype.SingleOrDefaultAsync(m => m.Id == id);
            if (gctype == null)
            {
                return NotFound();
            }

            _context.Gctype.Remove(gctype);
            await _context.SaveChangesAsync();

            return Ok(gctype);
        }

        private bool GctypeExists(int id)
        {
            return _context.Gctype.Any(e => e.Id == id);
        }
    }
}