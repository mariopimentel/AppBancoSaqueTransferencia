using Ninject.Modules;
using Stingy.Dominio.ContratoServicoDominio;
using Stingy.Dominio.Entidades;

namespace Stingy.Infra.IoC
{
    public class ModuloDosServicosDeDominio : NinjectModule
    {
        public override void Load()
        {
            Bind<IConta>().To<Conta>();
            Bind<ITransacoes>().To<Transacoes>();

        }
    }
}
