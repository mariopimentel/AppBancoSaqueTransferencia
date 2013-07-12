using System.Diagnostics;
using System.Web;
using NHibernate;

namespace Stingy.Infra.Repositorio.NH
{
    public static class HttpSessionManager
    {
        static ISession session;

        const string HttpNHibernateSession = "HttpNHibernateSession";

        public static ISession Session
        {
            set
            {
                if (HttpContext.Current == null)
                {
                    session = value;
                }
                else
                {
                    HttpContext.Current.Items[HttpNHibernateSession] = value;
                }
            }
            get
            {
                if (HttpContext.Current == null)
                {
                    return session;
                }
                else
                {
                    return (ISession) HttpContext.Current.Items[HttpNHibernateSession];
                }
            }
        }

        public static void CloseSession()
        {
            Debug.WriteLine("Close Session " + Session.GetHashCode());
            Session.Close();
        }

        public static void InitSession()
        {
            var sessionFactory = NHConfigurationForSQLServer.GetSessionFactory();
            Session = sessionFactory.OpenSession();
            Debug.WriteLine("Open Session " + Session.GetHashCode());

        }
    }
}