using NHibernate;
using Stingy.Infra.Servico.UnitOfWork;

namespace Stingy.Infra.Repositorio.NH
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISession session;

        public NHUnitOfWork(ISession session)
        {
            this.session = session;
            session.BeginTransaction();
        }

        public void Commit()
        {
            session.Transaction.Commit();
        }

        public void Rollback()
        {
            session.Transaction.Rollback();
        }

        public void Dispose()
        {
            if (session.Transaction.IsActive)
            {
                Rollback();                
            }
        }
    }
}