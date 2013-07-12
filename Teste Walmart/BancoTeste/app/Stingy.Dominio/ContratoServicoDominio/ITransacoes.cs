using System;
using Stingy.Dominio.Entidades;
using Stingy.Dominio.ObjetoDeValor;

namespace Stingy.Dominio.ContratoServicoDominio
{
    public interface ITransacoes
    {
        Conta ContaDestino { get; }
        Conta ContaOrigem { get; }
        TipoTransacao TipoTransacao { get; }
        DateTime DataTransacao { get; }
        decimal Valor { get; }


        void AdicionarContaOrigem(Conta conta);
        void AdicionarContaDestino(Conta conta);
        void AdicionarTipoTransacao(TipoTransacao tipoTransacao);
        void AdicionarValor(decimal valor);
        void FazerSaque();
        void FazerTransferencia();
    }
}
