using GerenciamentoFinanceiro.Model;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiro.Context
{
    public class ContaContext : DbContext
    {
        public ContaContext(DbContextOptions<ContaContext> options) : base(options)
        {

        }

        public DbSet<Conta> Contas { get; set; }
    }
}