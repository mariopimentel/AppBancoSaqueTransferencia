using Stingy.Dominio.ContratoServicoDominio;
using Stingy.Dominio.ObjetoDeValor;
using System;

namespace Stingy.Dominio.Entidades
{
    public class Transacoes : Entidade, ITransacoes
    {
        public virtual Conta ContaDestino { get; protected set; }
        public virtual Conta ContaOrigem { get; protected set; }
        public virtual TipoTransacao TipoTransacao { get; protected set; }
        public virtual DateTime DataTransacao { get; protected set; }
        public virtual decimal Valor { get; protected set; }

        protected Transacoes()
        {
        }

        public Transacoes(Conta contaOrigem, TipoTransacao tipoTransacao, decimal valor)
            : this()
        {
            AdicionarData();
            AdicionarContaOrigem(contaOrigem);
            AdicionarTipoTransacao(tipoTransacao);
            AdicionarValor(valor);
        }

        public virtual void AdicionarContaOrigem(Conta conta)
        {
            ContaOrigem = conta;
        }

        public virtual void AdicionarContaDestino(Conta conta)
        {
            ContaDestino = conta;
        }

        public virtual void AdicionarData()
        {
            DataTransacao = DateTime.Now;
        }

        public virtual void AdicionarTipoTransacao(TipoTransacao tipoTransacao)
        {
            TipoTransacao = tipoTransacao;
        }
        public virtual void AdicionarValor(decimal valor)
        {
            Valor = valor;
        }

        public virtual void FazerSaque()
        {
            if (ContaOrigem.Saldo < Valor)
                throw new Exception("Não tem Saldo suficiente.");

            ContaOrigem.RemoverSaldo(Valor);
        }

        public virtual void FazerTransferencia()
        {
            if (ContaDestino == null) throw new ArgumentNullException("ContaDestino");

            if (ContaOrigem == ContaDestino) throw new Exception("Contas deve ser diferentes");

            if (ContaOrigem.Saldo < Valor) throw new Exception("Não tem Saldo suficiente.");

            ContaOrigem.RemoverSaldo(Valor);
            ContaDestino.AdicionarSaldo(Valor);


        }
    }
}
