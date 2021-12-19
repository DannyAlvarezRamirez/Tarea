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
    public class CasasConstruidasController : ControllerBase
    {
        private readonly TareaContext _context;

        public CasasConstruidasController(TareaContext context)
        {
            _context = context;
        }

        // GET: api/CasasConstruidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CasaConstruida>>> GetCasaConstruida()
        {
            return await _context.CasaConstruida.ToListAsync();
        }

        // GET: api/CasasConstruidas/5
        [HttpGet]//("{id}")
        [Route("CasaConstruida")]
        public async Task<ActionResult<CasaConstruida>> GetCasaConstruida(int id)
        {
            var casaConstruida = await _context.CasaConstruida.FindAsync(id);

            if (casaConstruida == null)
            {
                return NotFound();
            }

            return casaConstruida;
        }

        // GET: api/CasasConstruidas/5
        [HttpGet]//("{id_Modelo}")]
        [Route("CasaConstruidaConModelo")]
        public ActionResult<IEnumerable<CasaConstruida>> GetCasaConstruidaConModelo(int Id_Modelo)
        {
            List<CasaConstruida> miListaCasasConstruidas , miListaCasasConstruidasFiltrada;
            miListaCasasConstruidas = _context.CasaConstruida.ToList();

            if (miListaCasasConstruidas == null)
            {
                return NotFound();
            }
            else
            {
                miListaCasasConstruidasFiltrada = miListaCasasConstruidas.Where(x => x.Id_Modelo == Id_Modelo).ToList();
            }

            return miListaCasasConstruidasFiltrada;
        }

        // PUT: api/CasasConstruidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]//("{id}")]
        [Route("CasaConstruida")]
        public async Task<IActionResult> PutCasaConstruida(int id, CasaConstruida casaConstruida)
        {
            if (id != casaConstruida.Id_Casa)
            {
                return BadRequest();
            }

            _context.Entry(casaConstruida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasaConstruidaExists(id))
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

        // PUT: api/CasasConstruidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]//("{id}")]
        [Route("CasaConstruidaConModelo")]
        public async Task<IActionResult> PutCasaConstruidaConModelo(int Id_Modelo, CasaConstruida casaConstruida)
        {
            if (Id_Modelo != casaConstruida.Id_Modelo)
            {
                return BadRequest();
            }

            _context.Entry(casaConstruida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasaConstruidaExists(Id_Modelo))
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

        // POST: api/CasasConstruidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CasaConstruida>> PostCasaConstruida(CasaConstruida casaConstruida)
        {
            _context.CasaConstruida.Add(casaConstruida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasaConstruida", new { id = casaConstruida.Id_Casa }, casaConstruida);
        }

        // DELETE: api/CasasConstruidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCasaConstruida(int id)
        {
            var casaConstruida = await _context.CasaConstruida.FindAsync(id);
            if (casaConstruida == null)
            {
                return NotFound();
            }

            _context.CasaConstruida.Remove(casaConstruida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CasaConstruidaExists(int id)
        {
            return _context.CasaConstruida.Any(e => e.Id_Casa == id);
        }
    }
}
