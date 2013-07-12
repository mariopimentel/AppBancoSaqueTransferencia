using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stingy.Dominio.ContratoServicoDominio;
using Stingy.Dominio.Entidades;
using Stingy.Dominio.Repositorios;

namespace Stingy.Dominio.Servico
{
    public class CursoServico : ICursoServico
    {
        ICursoRepositorio cursoRepositorio;
        public CursoServico()
        {

        }

        public CursoServico(ICursoRepositorio CursoRepositorio)
        {
            this.cursoRepositorio = CursoRepositorio;
        }

        public void DiminuirQuantidadeEstoqueCurso(int idCurso)
        {
            var curso = cursoRepositorio.Recuperar(idCurso);
            curso.QuantidadeEstoque--;

            cursoRepositorio.Salvar(curso);
        }

    }
}
