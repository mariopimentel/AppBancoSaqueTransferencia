using Stingy.Dominio.Entidades;
using Stingy.Dominio.Repositorios;

namespace Stingy.Dominio.ContratoServicoAplicacao
{
    public interface IContaServicoAplicacao : IRepositorioBase<Conta>
    {
        bool ExistesContasCadastradas();
    }
}
