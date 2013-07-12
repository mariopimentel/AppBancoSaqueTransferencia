using Stingy.Dominio.ContratoServicoDominio;

namespace Stingy.Dominio.Entidades
{
    public class Conta : Entidade, IConta
    {
        public virtual string NumeroConta { get; protected set; }
        public virtual string Agencia { get; protected set; }
        public virtual decimal Saldo { get; protected set; }


        protected Conta()
        {
            
        }

        public Conta(string numeroConta, string agencia, decimal saldo)
            : this()
        {

            AdicionarNumeroConta(numeroConta);
            AdicionarAgencia(agencia);
            PreencherSaldo(saldo);
        }

        public virtual void PreencherSaldo(decimal saldo)
        {
            Saldo = saldo;
        }

        public virtual void AdicionarSaldo(decimal saldo)
        {
            Saldo += saldo;
        }

        public virtual void RemoverSaldo(decimal saldo)
        {
            Saldo -= saldo;
        }

        public virtual void AdicionarAgencia(string agencia)
        {
            Agencia = agencia;
        }

        public virtual void AdicionarNumeroConta(string numeroConta)
        {
            NumeroConta = numeroConta;
        }

    }
}
