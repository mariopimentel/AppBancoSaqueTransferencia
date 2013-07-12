using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace Stingy.Infra.IoC
{
    internal class ResolvedorDeDependencia : IDependencyResolver
    {
        public IKernel Kernel { get; private set; }
        
        public ResolvedorDeDependencia(IKernel kernel)
        {
            Kernel = kernel;
        }


        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            return Kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        #endregion
    }
}