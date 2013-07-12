using System.Collections.Generic;
using System.Diagnostics;
using NHibernate;
using NHibernate.Linq;
using Stingy.Dominio.Repositorios;
using Stingy.Infra.Repositorio.NH;
using System.Linq;
using Stingy.Dominio.Entidades;

namespace Stingy.Infra.Repositorio
{
    public class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : Entidade
    {
        protected ISession Session
        {
            get
            {
                var session = HttpSessionManager.Session;
                Debug.WriteLine("Get Http Session in Repository " + session.GetHashCode());
                return session;
            }
        }

        public TEntidade Recuperar(int id)
        {
            return Session.Get<TEntidade>(id);
        }


        public List<TEntidade> Recuperar()
        {
            return Session.Query<TEntidade>().ToList();
        }

        public void Salvar(TEntidade entidade)
        {
            Session.SaveOrUpdate(entidade);
        }

        public void Excluir(TEntidade entidade)
        {
            Session.Delete(entidade);
        }

    }
}