using System.Collections.Generic;
using Stingy.Dominio.ObjetoDeValor;
using System.ComponentModel.DataAnnotations;

namespace Stingy.Web.Models
{
    public class TransacoesViewModel
    {

        public int Id { get; set; }
        public int IdContaOrigem { get; set; }
        public int IdContaDestino { get; set; }

        [Display(Name = "Tipo Trasação")]
        public TipoTransacao TipoTransacao { get; set; }

        [Display(Name = "Data Trasação")]
        public string DataTransacao { get; set; }

        [Required(ErrorMessage = "Valor Obrigatorio")]
        public string Valor { get; set; }

        [Display(Name = "Conta Destino")]
        public ContaViewModel ContaDestino { get; set; }

        [Display(Name = "Conta Origem")]
        public ContaViewModel ContaOrigem { get; set; }

        public List<ContaViewModel> ContasOrigem { get; set; }

        public List<ContaViewModel> ContasDestino
        {
            get
            {
                return ContasOrigem;
            }
        }

        public TransacoesViewModel()
        {
            ContasOrigem = new List<ContaViewModel>();
        }

    }
}