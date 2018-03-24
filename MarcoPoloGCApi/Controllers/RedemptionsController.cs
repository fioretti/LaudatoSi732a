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
    [Route("api/Redemptions")]
    public class RedemptionsController : Controller
    {
        private readonly MarcoPoloGCDBContext _context;

        public RedemptionsController(MarcoPoloGCDBContext context)
        {
            _context = context;
        }

        // GET: api/Redemptions
        [HttpGet]
        public IEnumerable<Gcredemption> GetGcredemption()
        {
            return _context.Gcredemption;
        }

        // GET: api/Redemptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGcredemption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcredemption = await _context.Gcredemption.SingleOrDefaultAsync(m => m.Id == id);

            if (gcredemption == null)
            {
                return NotFound();
            }

            return Ok(gcredemption);
        }

        // PUT: api/Redemptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGcredemption([FromRoute] int id, [FromBody] Gcredemption gcredemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gcredemption.Id)
            {
                return BadRequest();
            }

            _context.Entry(gcredemption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GcredemptionExists(id))
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

        // POST: api/Redemptions
        [HttpPost]
        public async Task<IActionResult> PostGcredemption([FromBody] Gcredemption gcredemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Gcredemption.Add(gcredemption);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGcredemption", new { id = gcredemption.Id }, gcredemption);
        }

        // DELETE: api/Redemptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGcredemption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcredemption = await _context.Gcredemption.SingleOrDefaultAsync(m => m.Id == id);
            if (gcredemption == null)
            {
                return NotFound();
            }

            _context.Gcredemption.Remove(gcredemption);
            await _context.SaveChangesAsync();

            return Ok(gcredemption);
        }

        private bool GcredemptionExists(int id)
        {
            return _context.Gcredemption.Any(e => e.Id == id);
        }
    }
}