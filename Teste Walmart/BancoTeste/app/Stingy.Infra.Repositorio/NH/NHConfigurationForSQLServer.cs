using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Stingy.Dominio;

namespace Stingy.Infra.Repositorio.NH
{
    public static class NHConfigurationForSQLServer
    {
        private static ISessionFactory sessionFactory;
        private static Configuration configuration;

        public static ISessionFactory GetSessionFactory()
        {
            if (sessionFactory == null)
            {
                sessionFactory = GetConfiguration().BuildSessionFactory();
            }
            return sessionFactory;
        }

        public static Configuration GetConfiguration()
        {
            if (configuration == null)
            {
                configuration = Fluently.Configure()
                    .ProxyFactoryFactory<NHibernate.ByteCode.Castle.ProxyFactoryFactory>()
                    .Database(MsSqlConfiguration.MsSql2008
                                  .ConnectionString(x => x.FromConnectionStringWithKey("StingyDb"))
                                  .ShowSql())
                    .Mappings(x => x.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .ExposeConfiguration(ExportSchemaConfiguration)
                    .BuildConfiguration();
            }
            return configuration;
        }

        public static void ExportSchemaConfiguration(Configuration configuration)
        {
            new SchemaExport(configuration)
                .Create(false, true);
        }
    }
}