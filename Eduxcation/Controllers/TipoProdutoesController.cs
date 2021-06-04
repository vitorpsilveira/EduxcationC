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

        // PUT: api/TipoProdutoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProduto(int id, TipoProduto tipoProduto)
        {
            if (id != tipoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoProdutoExists(id))
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

        // POST: api/TipoProdutoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TipoProduto>> PostTipoProduto(TipoProduto tipoProduto)
        {
            _context.TipoProdutos.Add(tipoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoProduto", new { id = tipoProduto.Id }, tipoProduto);
        }

        // DELETE: api/TipoProdutoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoProduto>> DeleteTipoProduto(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            _context.TipoProdutos.Remove(tipoProduto);
            await _context.SaveChangesAsync();

            return tipoProduto;
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.Id == id);
        }
    }
}
