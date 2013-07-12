using Stingy.Dominio.Entidades;
using Stingy.Dominio.Repositorios;

namespace Stingy.Dominio.ContratoRepositorios
{
    public interface IContaRepositorio : IRepositorioBase<Conta>
    {
        bool ExistesContasCadastradas();
    }
}
