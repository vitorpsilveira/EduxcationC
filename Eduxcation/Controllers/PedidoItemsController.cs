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

    }
}
