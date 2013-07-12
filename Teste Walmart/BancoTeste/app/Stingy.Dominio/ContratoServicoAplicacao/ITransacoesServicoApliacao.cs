using Stingy.Dominio.Entidades;
using Stingy.Dominio.Repositorios;

namespace Stingy.Dominio.ContratoServicoAplicacao
{
    public interface ITransacoesServicoApliacao : IRepositorioBase<Transacoes>
    {
        void Saque(int idContaOrgem, decimal valor);
        void Transferencia(int idContaOrgem, int idContaDestino, decimal valor);
    }
}
