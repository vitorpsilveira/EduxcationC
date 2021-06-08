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
    }
}
