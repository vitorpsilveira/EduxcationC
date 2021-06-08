using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eduxcation.Models;
using Eduxcation.Models.Request;
using Microsoft.Data.SqlClient;
using Eduxcation.Models.Response;

namespace Eduxcation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly EduxcationContext _context;

        public PedidosController(EduxcationContext context)
        {
            _context = context;

        }

        // GET: api/Pedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }

        // PUT: api/Pedidoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(pedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
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

        // POST: api/Pedidoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
		public async Task<ActionResult<PedidoResponse>> PostPedido(PedidoRequest pedido)
        {
            int ultimoPedido;

            _context.Database.ExecuteSqlCommand("Insert into Pedido values({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}); ",
                pedido.QtdProdutos, pedido.TotalProdutos, pedido.Frete, pedido.TotalPedido,
                pedido.ClienteId, pedido.DataPedido, pedido.CondicaoPagto, pedido.StatusPedido, pedido.Observacao);

            ultimoPedido = _context.Pedidos.ToList().LastOrDefault().Id;


            foreach (var item in pedido.PedidoItem)
            {
                _context.Database.ExecuteSqlCommand("Insert into Pedido_Item values({0}, {1}, {2}, {3}, {4});", ultimoPedido, 
                    item.ProdutoId, item.QtdProduto, item.PrecoUnitario, item.Total
                    );
            }
            await _context.SaveChangesAsync();



            return CreatedAtAction("GetPedido", new { id = ultimoPedido }, pedido);
        }

        // DELETE: api/Pedidoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> DeletePedido(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
