using Ninject.Modules;
using Stingy.Dominio.ContratoServicoAplicacao;
using Stingy.ServicoDeAplicacao;

namespace Stingy.Infra.IoC
{
    public class ModuloDosServicosDeAplicacao : NinjectModule
    {
        public override void Load()
        {

            Bind<IContaServicoAplicacao>().To<ContaServicoApliacao>();
            Bind<ITransacoesServicoApliacao>().To<TransacoesServicoApliacao>();

        }
    }
}
