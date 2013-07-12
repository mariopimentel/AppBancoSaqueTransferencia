using Stingy.Dominio.ContratoRepositorios;
using Stingy.Dominio.Entidades;

namespace Stingy.Infra.Repositorio
{
    public class TransacoesRepositorio : RepositorioBase<Transacoes>, ITransacoesRepositorio
    {
        public TransacoesRepositorio()
        {
        }
    }
}
