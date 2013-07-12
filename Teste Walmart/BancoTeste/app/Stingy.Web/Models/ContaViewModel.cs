using System.ComponentModel.DataAnnotations;

namespace Stingy.Web.Models
{
    public class ContaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Numero Conta")]
        [Required(ErrorMessage = "Numero Conta Obrigatorio")]
        public string NumeroConta { get; set; }

        [Required(ErrorMessage = "Agencia Obrigatorio")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "Saldo Obrigatorio")]
        public string Saldo { get; set; }
    }
}