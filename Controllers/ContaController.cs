using GerenciamentoFinanceiro.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

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

        private bool ContaExists(Guid id)
        {
            return(_context.Contas?.Any(conta => conta.ID == id)).GetValueOrDefault();
        }
    }
}