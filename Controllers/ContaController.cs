using GerenciamentoFinanceiro.Context;
using GerenciamentoFinanceiro.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiro.Controller
{
    [Microsoft.AspNetCore.Mvc.Route("Contas")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly ContaContext? _context;

        public ContaController(ContaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conta>>> GetConta()
        {
            if(_context.Contas == null)
            {
                return NotFound();
            }

            return await _context.Contas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(Guid id)
        {
            if(_context.Contas == null)
            {
                return NotFound();
            }

            var conta = await _context.Contas.FindAsync(id);

            if(conta == null)
            {
                return NotFound();
            }

            return conta;
        }

        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta)
        {
            if(_context.Contas == null)
            {
                return Problem("Construtor vazio!");
            }

            _context.Contas.Add(conta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContas", new { id = conta.ID }, conta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConta(Guid id, Conta conta)
        {
            if(conta.ID != id)
            {
                return BadRequest();
            }

            _context.Contas.Entry(conta).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ContaExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(Guid id)
        {
            if(_context.Contas == null)
            {
                return NotFound();
            }

            var conta = await _context.Contas.FindAsync(id);

            if(conta == null)
            {
                return NotFound();
            }

            _context.Contas.Remove(conta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContaExists(Guid id)
        {
            return(_context.Contas?.Any(conta => conta.ID == id)).GetValueOrDefault();
        }
    }
}