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
    public class TipoProdutoesController : ControllerBase
    {
        private readonly EduxcationContext _context;

        public TipoProdutoesController(EduxcationContext context)
        {
            _context = context;
        }

        // GET: api/TipoProdutoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProduto>>> GetTipoProdutos()
        {
            return await _context.TipoProdutos.ToListAsync();
        }

        // GET: api/TipoProdutoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProduto>> GetTipoProduto(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);

            if (tipoProduto == null)
            {
                return NotFound();
            }

            return tipoProduto;
        }
    }
}
