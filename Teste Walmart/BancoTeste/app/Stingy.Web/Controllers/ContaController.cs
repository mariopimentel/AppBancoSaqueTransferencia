using Stingy.Dominio.ContratoServicoAplicacao;
using Stingy.Dominio.Entidades;
using Stingy.Web.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Stingy.Web.Controllers
{
    public class ContaController : Controller
    {
        private readonly IContaServicoAplicacao _contaServicoAplicacao;

        public ContaController(IContaServicoAplicacao ContaServicoAplicacao)
        {
            _contaServicoAplicacao = ContaServicoAplicacao;
        }

        public ActionResult Index()
        {
            var contas = _contaServicoAplicacao.Recuperar();
            var model = contas.Select(x => new ContaViewModel()
                                               {
                                                   Id = x.Id,
                                                   Agencia = x.Agencia,
                                                   NumeroConta = x.NumeroConta,
                                                   Saldo = x.Saldo.ToString()
                                               });
            return View(model);
        }

        #region Criar Conta

        public ActionResult Criar()
        {
            var model = new ContaViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Criar(ContaViewModel model)
        {
            try
            {
                _contaServicoAplicacao.Salvar(new Conta(model.NumeroConta, model.Agencia, Convert.ToDecimal(model.Saldo)));

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        #endregion

        #region Editar Conta

        public ActionResult Editar(int id)
        {
            var conta = _contaServicoAplicacao.Recuperar(id);
            var model = new ContaViewModel()
            {
                Id = conta.Id,
                NumeroConta = conta.NumeroConta,
                Agencia = conta.Agencia,
                Saldo = conta.Saldo.ToString()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(int id, ContaViewModel model)
        {
            try
            {
                var conta = _contaServicoAplicacao.Recuperar(id);
                conta.AdicionarAgencia(model.Agencia);
                conta.AdicionarNumeroConta(model.NumeroConta);
                conta.PreencherSaldo(Convert.ToDecimal(model.Saldo));

                _contaServicoAplicacao.Salvar(conta);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        #endregion

        #region Remover Conta

        public ActionResult Deletar(int id)
        {
            try
            {
                _contaServicoAplicacao.Excluir(_contaServicoAplicacao.Recuperar(id));

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        #endregion




    }
}
