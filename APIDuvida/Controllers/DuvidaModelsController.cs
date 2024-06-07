using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIDuvida.Data;
using Models;

namespace APIDuvida.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuvidaModelsController : ControllerBase
    {
        private readonly APIDuvidaContext _context;

        public DuvidaModelsController(APIDuvidaContext context)
        {
            _context = context;
        }

        // GET: api/DuvidaModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DuvidaModel>>> GetDuvidaModel()
        {
          if (_context.DuvidaModel == null)
          {
              return NotFound();
          }
            return await _context.DuvidaModel.ToListAsync();
        }

        // GET: api/DuvidaModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuvidaModel>> GetDuvidaModel(int id)
        {
          if (_context.DuvidaModel == null)
          {
              return NotFound();
          }
            var duvidaModel = await _context.DuvidaModel.FindAsync(id);

            if (duvidaModel == null)
            {
                return NotFound();
            }

            return duvidaModel;
        }

        // PUT: api/DuvidaModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuvidaModel(int id, DuvidaModel duvidaModel)
        {
            if (id != duvidaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(duvidaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuvidaModelExists(id))
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

        // POST: api/DuvidaModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DuvidaModel>> PostDuvidaModel(DuvidaModel duvidaModel)
        {
          if (_context.DuvidaModel == null)
          {
              return Problem("Entity set 'APIDuvidaContext.DuvidaModel'  is null.");
          }
            _context.DuvidaModel.Add(duvidaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDuvidaModel", new { id = duvidaModel.Id }, duvidaModel);
        }

        // DELETE: api/DuvidaModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDuvidaModel(int id)
        {
            if (_context.DuvidaModel == null)
            {
                return NotFound();
            }
            var duvidaModel = await _context.DuvidaModel.FindAsync(id);
            if (duvidaModel == null)
            {
                return NotFound();
            }

            _context.DuvidaModel.Remove(duvidaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DuvidaModelExists(int id)
        {
            return (_context.DuvidaModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
