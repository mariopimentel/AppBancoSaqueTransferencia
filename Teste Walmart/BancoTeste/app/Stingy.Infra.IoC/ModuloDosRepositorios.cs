using Ninject.Modules;
using Stingy.Dominio.ContratoRepositorios;
using Stingy.Infra.Repositorio;
using Stingy.Infra.Repositorio.NH;
using Stingy.Infra.Servico.UnitOfWork;
namespace Stingy.Infra.IoC
{
    public class ModuloDosRepositorios : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWorkFactory>().To<NHUnitOfWorkFactory>();
            Bind<IContaRepositorio>().To<ContaRepositorio>();
            Bind<ITransacoesRepositorio>().To<TransacoesRepositorio>();

        }
    }
}
