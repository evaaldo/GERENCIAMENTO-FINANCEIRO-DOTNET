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

        private bool ContaExists(Guid id)
        {
            return(_context.Contas?.Any(conta => conta.ID == id)).GetValueOrDefault();
        }
    }
}