using System;
using Microsoft.Practices.ServiceLocation;
using Stingy.Infra.Servico.UnitOfWork;

namespace Stingy.ServicoDeAplicacao
{
    public class ServicoBase
    {
        protected IUnitOfWorkFactory UoWFactory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IUnitOfWorkFactory>();
            }
        }
    }
}
