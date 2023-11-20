using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiro.Model
{
    public class Conta
    {
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Dono { get; set; } = string.Empty;
        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public decimal Receita { get; set; }
        [Required]
        public decimal Despesa { get; set; }
    }
}