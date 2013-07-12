using System.Web.Mvc;
using Stingy.Dominio.ContratoServicoAplicacao;
using Stingy.Dominio.Entidades;

namespace Stingy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContaServicoAplicacao _contaServicoAplicacao;

        public HomeController(IContaServicoAplicacao ContaServicoAplicacao)
        {
            _contaServicoAplicacao = ContaServicoAplicacao;
        }

        public ActionResult Index()
        {
            CriarContas();
            return RedirectToAction("Index", "Conta");
        }

        public ActionResult About()
        {
            return View();
        }

        #region Metodos

        private void CriarContas()
        {
            if (!_contaServicoAplicacao.ExistesContasCadastradas())
            {
                var conta = new Conta("1023-2", "2323-1", 1000);
                var conta1 = new Conta("4435-2", "234323-1", 4500);
                var conta2 = new Conta("3481-2", "5766-1", 320);

                _contaServicoAplicacao.Salvar(conta);
                _contaServicoAplicacao.Salvar(conta1);
                _contaServicoAplicacao.Salvar(conta2);
            }

        }
        #endregion

    }
}
