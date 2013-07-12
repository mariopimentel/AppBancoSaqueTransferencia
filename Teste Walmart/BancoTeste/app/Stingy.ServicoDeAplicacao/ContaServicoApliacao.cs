using System.Collections.Generic;
using System.Linq;
using Stingy.Dominio.ContratoRepositorios;
using Stingy.Dominio.ContratoServicoAplicacao;
using Stingy.Dominio.Entidades;

namespace Stingy.ServicoDeAplicacao
{
    public class ContaServicoApliacao : ServicoBase, IContaServicoAplicacao
    {
        IContaRepositorio contaRepositorio;
        public ContaServicoApliacao(IContaRepositorio ContaRepositorio)
        {
            contaRepositorio = ContaRepositorio;
        }

        public Conta Recuperar(int id)
        {
            return contaRepositorio.Recuperar(id);
        }

  
        public void Salvar(Conta entidade)
        {
            using (var uow = UoWFactory.Create())
            {
                contaRepositorio.Salvar(entidade);
                uow.Commit();
            }
        }

        public void Excluir(Conta entidade)
        {
            using (var uow = UoWFactory.Create())
            {
                contaRepositorio.Excluir(entidade);
                uow.Commit();
            }
        }

        public List<Conta> Recuperar()
        {
            return contaRepositorio.Recuperar();
        }

        public bool ExistesContasCadastradas()
        {
            return contaRepositorio.ExistesContasCadastradas();
        }
    }
}
