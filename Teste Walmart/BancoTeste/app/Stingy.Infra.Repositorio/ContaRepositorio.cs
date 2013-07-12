using System.Linq;
using NHibernate.Linq;
using Stingy.Dominio.ContratoRepositorios;
using Stingy.Dominio.Entidades;

namespace Stingy.Infra.Repositorio
{
    public class ContaRepositorio : RepositorioBase<Conta>, IContaRepositorio
    {
        public ContaRepositorio()
        {

        }

        public bool ExistesContasCadastradas()
        {
            return Session.Query<Conta>().Any();
        }
    }
}
