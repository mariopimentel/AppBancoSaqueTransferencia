using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Stingy.Infra.Repositorio.NH;

namespace Stingy.Infra.IoC
{
    public static class IoC
    {
        public static void IniciarHttpRequest()
        {
            HttpSessionManager.InitSession();
        }
        public static void TerminarHttpRequest()
        {
            HttpSessionManager.CloseSession();
        }
        public static void RegistrarModulos()
        {
            var kernel = new StandardKernel(new ModuloDosRepositorios(), new ModuloDosServicosDeAplicacao(), new ModuloDosServicosDeDominio());

            DependencyResolver.SetResolver(new ResolvedorDeDependencia(kernel));
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
        }
    }
}
