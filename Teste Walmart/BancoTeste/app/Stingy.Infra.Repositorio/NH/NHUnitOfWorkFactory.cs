using System.Diagnostics;
using Stingy.Infra.Servico.UnitOfWork;

namespace Stingy.Infra.Repositorio.NH
{
    public class NHUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            var session = HttpSessionManager.Session;
            Debug.WriteLine("Get Http Session in Unit of Work " + session.GetHashCode());

            return new NHUnitOfWork(session);
        }
    }
}