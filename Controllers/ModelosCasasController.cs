using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea.Data;
using Tarea.Models;

namespace Tarea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosCasasController : ControllerBase
    {
        private readonly TareaContext _context;

        public ModelosCasasController(TareaContext context)
        {
            _context = context;
        }

        // GET: api/ModelosCasas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeloCasa>>> GetModeloCasa()
        {
            return await _context.ModeloCasa.ToListAsync();
        }

        // GET: api/ModelosCasas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloCasa>> GetModeloCasa(int id)
        {
            var modeloCasa = await _context.ModeloCasa.FindAsync(id);

            if (modeloCasa == null)
            {
                return NotFound();
            }

            return modeloCasa;
        }

        // PUT: api/ModelosCasas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModeloCasa(int id, ModeloCasa modeloCasa)
        {
            if (id != modeloCasa.Id_Modelo || modeloCasa.Es_De_Dos_Plantas != 1 ||
                modeloCasa.Es_De_Dos_Plantas != 0 ||
                modeloCasa.Tiene_Cochera_Techada != 1 ||
                modeloCasa.Tiene_Cochera_Techada != 0)
            {
                return BadRequest();
            }
            
            _context.Entry(modeloCasa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeloCasaExists(id))
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

        // POST: api/ModelosCasas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModeloCasa>> PostModeloCasa(ModeloCasa modeloCasa)
        {
            if (modeloCasa.Es_De_Dos_Plantas == 1 ||
                modeloCasa.Es_De_Dos_Plantas == 0 &&
                modeloCasa.Tiene_Cochera_Techada == 1 ||
                modeloCasa.Tiene_Cochera_Techada == 0)
            {
                _context.ModeloCasa.Add(modeloCasa);
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest();
            }

            return CreatedAtAction("GetModeloCasa", new { id = modeloCasa.Id_Modelo }, modeloCasa);
        }

        // DELETE: api/ModelosCasas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModeloCasa(int id)
        {
            var modeloCasa = await _context.ModeloCasa.FindAsync(id);
            if (modeloCasa == null)
            {
                return NotFound();
            }

            _context.ModeloCasa.Remove(modeloCasa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeloCasaExists(int id)
        {
            return _context.ModeloCasa.Any(e => e.Id_Modelo == id);
        }
    }
}
