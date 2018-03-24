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
    [Route("api/Purchases")]
    public class PurchasesController : Controller
    {
        private readonly MarcoPoloGCDBContext _context;

        public PurchasesController(MarcoPoloGCDBContext context)
        {
            _context = context;
        }

        // GET: api/Purchases
        [HttpGet]
        public IEnumerable<Gcpurchase> GetGcpurchase()
        {
            return _context.Gcpurchase;
        }

        // GET: api/Purchases/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGcpurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcpurchase = await _context.Gcpurchase.SingleOrDefaultAsync(m => m.Id == id);

            if (gcpurchase == null)
            {
                return NotFound();
            }

            return Ok(gcpurchase);
        }

        // PUT: api/Purchases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGcpurchase([FromRoute] int id, [FromBody] Gcpurchase gcpurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gcpurchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(gcpurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GcpurchaseExists(id))
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

        // POST: api/Purchases
        [HttpPost]
        public async Task<IActionResult> PostGcpurchase([FromBody] Gcpurchase gcpurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Gcpurchase.Add(gcpurchase);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGcpurchase", new { id = gcpurchase.Id }, gcpurchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGcpurchase([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcpurchase = await _context.Gcpurchase.SingleOrDefaultAsync(m => m.Id == id);
            if (gcpurchase == null)
            {
                return NotFound();
            }

            _context.Gcpurchase.Remove(gcpurchase);
            await _context.SaveChangesAsync();

            return Ok(gcpurchase);
        }

        private bool GcpurchaseExists(int id)
        {
            return _context.Gcpurchase.Any(e => e.Id == id);
        }
    }
}