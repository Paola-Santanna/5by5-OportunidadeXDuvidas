using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIOportunidade.Data;
using Models;

namespace APIOportunidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OportunidadeModelsController : ControllerBase
    {
        private readonly APIOportunidadeContext _context;

        public OportunidadeModelsController(APIOportunidadeContext context)
        {
            _context = context;
        }

        // GET: api/OportunidadeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OportunidadeModel>>> GetOportunidadeModel()
        {
          if (_context.OportunidadeModel == null)
          {
              return NotFound();
          }
            return await _context.OportunidadeModel.ToListAsync();
        }

        // GET: api/OportunidadeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OportunidadeModel>> GetOportunidadeModel(int id)
        {
          if (_context.OportunidadeModel == null)
          {
              return NotFound();
          }
            var oportunidadeModel = await _context.OportunidadeModel.FindAsync(id);

            if (oportunidadeModel == null)
            {
                return NotFound();
            }

            return oportunidadeModel;
        }

        // PUT: api/OportunidadeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOportunidadeModel(int id, OportunidadeModel oportunidadeModel)
        {
            if (id != oportunidadeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(oportunidadeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OportunidadeModelExists(id))
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

        // POST: api/OportunidadeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OportunidadeModel>> PostOportunidadeModel(OportunidadeModel oportunidadeModel)
        {
          if (_context.OportunidadeModel == null)
          {
              return Problem("Entity set 'APIOportunidadeContext.OportunidadeModel'  is null.");
          }
            _context.OportunidadeModel.Add(oportunidadeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOportunidadeModel", new { id = oportunidadeModel.Id }, oportunidadeModel);
        }

        // DELETE: api/OportunidadeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOportunidadeModel(int id)
        {
            if (_context.OportunidadeModel == null)
            {
                return NotFound();
            }
            var oportunidadeModel = await _context.OportunidadeModel.FindAsync(id);
            if (oportunidadeModel == null)
            {
                return NotFound();
            }

            _context.OportunidadeModel.Remove(oportunidadeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OportunidadeModelExists(int id)
        {
            return (_context.OportunidadeModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
