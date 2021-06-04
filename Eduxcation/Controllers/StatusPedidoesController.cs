using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eduxcation.Models;

namespace Eduxcation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusPedidoesController : ControllerBase
    {
        private readonly EduxcationContext _context;

        public StatusPedidoesController(EduxcationContext context)
        {
            _context = context;
        }

        // GET: api/StatusPedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusPedido>>> GetStatusPedidos()
        {
            return await _context.StatusPedidos.ToListAsync();
        }

        // GET: api/StatusPedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusPedido>> GetStatusPedido(int id)
        {
            var statusPedido = await _context.StatusPedidos.FindAsync(id);

            if (statusPedido == null)
            {
                return NotFound();
            }

            return statusPedido;
        }

        // PUT: api/StatusPedidoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusPedido(int id, StatusPedido statusPedido)
        {
            if (id != statusPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(statusPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusPedidoExists(id))
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

        // POST: api/StatusPedidoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StatusPedido>> PostStatusPedido(StatusPedido statusPedido)
        {
            _context.StatusPedidos.Add(statusPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusPedido", new { id = statusPedido.Id }, statusPedido);
        }

        // DELETE: api/StatusPedidoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StatusPedido>> DeleteStatusPedido(int id)
        {
            var statusPedido = await _context.StatusPedidos.FindAsync(id);
            if (statusPedido == null)
            {
                return NotFound();
            }

            _context.StatusPedidos.Remove(statusPedido);
            await _context.SaveChangesAsync();

            return statusPedido;
        }

        private bool StatusPedidoExists(int id)
        {
            return _context.StatusPedidos.Any(e => e.Id == id);
        }
    }
}
