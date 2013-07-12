using System.Collections.Generic;
using Stingy.Dominio.ContratoRepositorios;
using Stingy.Dominio.ContratoServicoAplicacao;
using Stingy.Dominio.Entidades;
using Stingy.Dominio.ObjetoDeValor;

namespace Stingy.ServicoDeAplicacao
{
    public class TransacoesServicoApliacao : ServicoBase, ITransacoesServicoApliacao
    {
        ITransacoesRepositorio transacoesRepositorio;
        private IContaServicoAplicacao contaServicoAplicacao;
        public TransacoesServicoApliacao(ITransacoesRepositorio TransacoesRepositorio, IContaServicoAplicacao ContaServicoAplicacao)
        {
            transacoesRepositorio = TransacoesRepositorio;
            contaServicoAplicacao = ContaServicoAplicacao;
        }

        public void Saque(int idContaOrgem, decimal valor)
        {
            var conta = contaServicoAplicacao.Recuperar(idContaOrgem);
            var transacao = new Transacoes(conta, TipoTransacao.Saque, valor);
            transacao.FazerSaque();
            Salvar(transacao);
        }

        public void Transferencia(int idContaOrgem, int idContaDestino, decimal valor)
        {
            var origem = contaServicoAplicacao.Recuperar(idContaOrgem);
            var destino = contaServicoAplicacao.Recuperar(idContaDestino);

            var transacao = new Transacoes(origem, TipoTransacao.Saque, valor);
            transacao.AdicionarContaDestino(destino);
            transacao.FazerTransferencia();
            Salvar(transacao);
        }

        public Transacoes Recuperar(int id)
        {
            return transacoesRepositorio.Recuperar(id);
        }

        public void Salvar(Transacoes entidade)
        {
            using (var uow = UoWFactory.Create())
            {
                transacoesRepositorio.Salvar(entidade);
                uow.Commit();
            }
        }

        public void Excluir(Transacoes entidade)
        {
            using (var uow = UoWFactory.Create())
            {
                transacoesRepositorio.Excluir(entidade);
                uow.Commit();
            }
        }

        public List<Transacoes> Recuperar()
        {
            return transacoesRepositorio.Recuperar();
        }

    }
}
