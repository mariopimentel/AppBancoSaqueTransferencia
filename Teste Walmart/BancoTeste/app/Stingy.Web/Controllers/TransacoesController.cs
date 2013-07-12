using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stingy.Dominio.ContratoServicoAplicacao;
using Stingy.Dominio.Entidades;
using Stingy.Web.Models;

namespace Stingy.Web.Controllers
{
    public class TransacoesController : Controller
    {
        private readonly ITransacoesServicoApliacao _transacoesServicoAplicacao;
        private readonly IContaServicoAplicacao _contaServicoAplicacao;

        public TransacoesController(ITransacoesServicoApliacao TransacoesServicoAplicacao, IContaServicoAplicacao contaServicoAplicacao)
        {
            _transacoesServicoAplicacao = TransacoesServicoAplicacao;
            _contaServicoAplicacao = contaServicoAplicacao;
        }



        public ActionResult Index()
        {
            var transacoes = _transacoesServicoAplicacao.Recuperar();
            var model = transacoes.Select(x => new TransacoesViewModel()
                                                   {
                                                       Id = x.Id,
                                                       DataTransacao = x.DataTransacao.ToShortDateString(),
                                                       Valor = x.Valor.ToString(),
                                                       TipoTransacao = x.TipoTransacao,
                                                       ContaOrigem = ObterConta(x.ContaOrigem),
                                                       ContaDestino = x.ContaDestino == null
                                                                     ? new ContaViewModel() : ObterConta(x.ContaDestino)
                                                   });

            return View(model);
        }


        public ActionResult Saque()
        {
            var model = new TransacoesViewModel
                            {
                                ContasOrigem = ObterContas()
                            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Saque(TransacoesViewModel model)
        {
            try
            {
                _transacoesServicoAplicacao.Saque(model.IdContaOrigem, Convert.ToDecimal(model.Valor));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
            }

            model.ContasOrigem = ObterContas();
            return View(model);
        }

        public ActionResult Transferencia()
        {
            var model = new TransacoesViewModel
            {
                ContasOrigem = ObterContas()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Transferencia(TransacoesViewModel model)
        {
            try
            {
                _transacoesServicoAplicacao.Transferencia(model.IdContaOrigem, model.IdContaDestino, Convert.ToDecimal(model.Valor));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ViewBag.msg = ex.Message;
            }

            model.ContasOrigem = ObterContas();
            return View(model);
        }


        #region Metodos Privados

        private ContaViewModel ObterConta(Conta conta)
        {
            return new ContaViewModel
            {
                Id = conta.Id,
                Agencia = conta.Agencia,
                NumeroConta = conta.NumeroConta,
                Saldo = conta.Saldo.ToString()
            };
        }

        private List<ContaViewModel> ObterContas()
        {
            var contas = _contaServicoAplicacao.Recuperar();
            return contas.Select(ObterConta).ToList();
        }
        #endregion

    }
}
