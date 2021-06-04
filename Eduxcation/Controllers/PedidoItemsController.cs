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
    public class PedidoItemsController : ControllerBase
    {
        private readonly EduxcationContext _context;

        public PedidoItemsController(EduxcationContext context)
        {
            _context = context;
        }

        // GET: api/PedidoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoItem>>> GetPedidoItems()
        {
            return await _context.PedidoItems.ToListAsync();
        }

        // GET: api/PedidoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoItem>> GetPedidoItem(int id)
        {
            var pedidoItem = await _context.PedidoItems.FindAsync(id);

            if (pedidoItem == null)
            {
                return NotFound();
            }

            return pedidoItem;
        }

        // PUT: api/PedidoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoItem(int id, PedidoItem pedidoItem)
        {
            if (id != pedidoItem.PedidoId)
            {
                return BadRequest();
            }

            _context.Entry(pedidoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoItemExists(id))
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

        // POST: api/PedidoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PedidoItem>> PostPedidoItem(PedidoItem pedidoItem)
        {
            _context.PedidoItems.Add(pedidoItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PedidoItemExists(pedidoItem.PedidoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPedidoItem", new { id = pedidoItem.PedidoId }, pedidoItem);
        }

        // DELETE: api/PedidoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoItem>> DeletePedidoItem(int id)
        {
            var pedidoItem = await _context.PedidoItems.FindAsync(id);
            if (pedidoItem == null)
            {
                return NotFound();
            }

            _context.PedidoItems.Remove(pedidoItem);
            await _context.SaveChangesAsync();

            return pedidoItem;
        }

        private bool PedidoItemExists(int id)
        {
            return _context.PedidoItems.Any(e => e.PedidoId == id);
        }
    }
}
