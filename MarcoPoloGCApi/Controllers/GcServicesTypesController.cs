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
    [Route("api/GcServicesTypes")]
    public class GcServicesTypesController : Controller
    {
        private readonly MarcoPoloGCDBContext _context;

        public GcServicesTypesController(MarcoPoloGCDBContext context)
        {
            _context = context;
        }

        // GET: api/GcServicesTypes
        [HttpGet]
        public IEnumerable<GcservicesType> GetGcservicesType()
        {
            return _context.GcservicesType;
        }

        // GET: api/GcServicesTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGcservicesType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcservicesType = await _context.GcservicesType.SingleOrDefaultAsync(m => m.Id == id);

            if (gcservicesType == null)
            {
                return NotFound();
            }

            return Ok(gcservicesType);
        }

        // PUT: api/GcServicesTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGcservicesType([FromRoute] int id, [FromBody] GcservicesType gcservicesType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gcservicesType.Id)
            {
                return BadRequest();
            }

            _context.Entry(gcservicesType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GcservicesTypeExists(id))
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

        // POST: api/GcServicesTypes
        [HttpPost]
        public async Task<IActionResult> PostGcservicesType([FromBody] GcservicesType gcservicesType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GcservicesType.Add(gcservicesType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGcservicesType", new { id = gcservicesType.Id }, gcservicesType);
        }

        // DELETE: api/GcServicesTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGcservicesType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gcservicesType = await _context.GcservicesType.SingleOrDefaultAsync(m => m.Id == id);
            if (gcservicesType == null)
            {
                return NotFound();
            }

            _context.GcservicesType.Remove(gcservicesType);
            await _context.SaveChangesAsync();

            return Ok(gcservicesType);
        }

        private bool GcservicesTypeExists(int id)
        {
            return _context.GcservicesType.Any(e => e.Id == id);
        }
    }
}