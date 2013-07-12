using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using MvcContrib.TestHelper;
using NUnit.Framework;
using Stingy.Web.Controllers;

namespace Stingy.Web.Test
{
    [TestFixture]
    public class TesteDeRotas
    {
        [SetUp]
        public void IniciarTeste()
        {
            Stingy.Web.MvcApplication.RegisterRoutes(RouteTable.Routes);
        }

        [TearDown]
        public void LimparTeste()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void Rota_padrão_quando_chama_home_index()
        {
            "~/Home/Index".ShouldMapTo<HomeController>(x => x.Index());
        }

        [Test]
        public void Rota_padrão_quando_chama_home()
        {
            "~/Home".ShouldMapTo<HomeController>(x => x.Index());
        }

        [Test]
        public void Rota_padrão_quando_chama_home_about()
        {
            "~/Home/about".ShouldMapTo<HomeController>(x => x.About());
        }
    }
}