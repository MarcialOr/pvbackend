using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pvbackend.Models;

namespace pvbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoencabezadoController : ControllerBase
    {
        private readonly marcialdbContext _context;

        public PedidoencabezadoController(marcialdbContext context)
        {
            _context = context;
        }

        // GET: api/Pedidoencabezado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidoencabezado>>> GetPedidoencabezado()
        {
            return await _context.Pedidoencabezado.ToListAsync();
        }

        // GET: api/Pedidoencabezado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidoencabezado>> GetPedidoencabezado(int id)
        {
            var pedidoencabezado = await _context.Pedidoencabezado.FindAsync(id);

            if (pedidoencabezado == null)
            {
                return NotFound();
            }

            return pedidoencabezado;
        }

        // PUT: api/Pedidoencabezado/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoencabezado(int id, Pedidoencabezado pedidoencabezado)
        {
            if (id != pedidoencabezado.Pedidoid)
            {
                return BadRequest();
            }

            _context.Entry(pedidoencabezado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoencabezadoExists(id))
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

        // POST: api/Pedidoencabezado
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pedidoencabezado>> PostPedidoencabezado(Pedidoencabezado pedidoencabezado)
        {
            _context.Pedidoencabezado.Add(pedidoencabezado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoencabezado", new { id = pedidoencabezado.Pedidoid }, pedidoencabezado);
        }

        // DELETE: api/Pedidoencabezado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedidoencabezado>> DeletePedidoencabezado(int id)
        {
            var pedidoencabezado = await _context.Pedidoencabezado.FindAsync(id);
            if (pedidoencabezado == null)
            {
                return NotFound();
            }

            _context.Pedidoencabezado.Remove(pedidoencabezado);
            await _context.SaveChangesAsync();

            return pedidoencabezado;
        }

        private bool PedidoencabezadoExists(int id)
        {
            return _context.Pedidoencabezado.Any(e => e.Pedidoid == id);
        }
    }
}
