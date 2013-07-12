using System;

namespace Stingy.Dominio.ContratoServicoDominio
{
    public interface IConta
    {
        string NumeroConta { get; }
        string Agencia { get; }
        decimal Saldo { get; }


        void AdicionarNumeroConta(string numeroConta);
        void AdicionarAgencia(string agencia);
        void RemoverSaldo(decimal saldo);
        void AdicionarSaldo(decimal saldo);
        void PreencherSaldo(decimal saldo);
    }
}
