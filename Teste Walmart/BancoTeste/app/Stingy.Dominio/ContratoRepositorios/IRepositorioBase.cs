using System.Collections.Generic;
using Stingy.Dominio.Entidades;
namespace Stingy.Dominio.Repositorios
{
    public interface IRepositorioBase<TEntidade> where TEntidade : Entidade
    {
        TEntidade Recuperar(int id);
        void Salvar(TEntidade entidade);
        void Excluir(TEntidade entidade);

        List<TEntidade> Recuperar();
    }
}