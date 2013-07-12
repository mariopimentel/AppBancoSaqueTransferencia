using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stingy.Dominio.ContratoServicoDominio;
using Stingy.Dominio.Entidades;
using Stingy.Dominio.ObjetoDeValor;
using Stingy.Dominio.Repositorios;
using Stingy.Dominio.ServicoAplicacao;

namespace Stingy.Dominio.Servico
{
    public class PedidoServico : IPedidoServico
    {
        IPedidoRepositorio pedidoRepositorio;
        IItemPedidoRepositorio itemPedidoRepositorio;
        ICursoRepositorio cursoRepositorio;
        ICarrinhoDeCompraServicoAplicacao carrinhoDeCompraServicoAplicacao;

        public PedidoServico(IPedidoRepositorio PedidoRepositorio, ICursoRepositorio CursoRepositorio, ICarrinhoDeCompraServicoAplicacao CarrinhoDeCompraServicoAplicacao, IItemPedidoRepositorio ItemPedidoRepositorio)
        {
            this.pedidoRepositorio = PedidoRepositorio;
            this.cursoRepositorio = CursoRepositorio;
            this.carrinhoDeCompraServicoAplicacao = CarrinhoDeCompraServicoAplicacao;
            this.itemPedidoRepositorio = ItemPedidoRepositorio;
        }

        public PedidoServico()
        {

        }

        public Pedido GerarPedidoAPartirDoCarrinhoDeCompras(int FormaPagamento)
        {
            var carrinhoDeCompra = carrinhoDeCompraServicoAplicacao.RecuperarCarrinho();

            if (ValidaSeTemEstoque(carrinhoDeCompra))
            {
                var novoPedido = new Pedido
                {
                    ValorTotal = carrinhoDeCompra.ValorTotal,
                    DataHora = DateTime.Now,
                    FormaPagamento = FormaPagamento
                };

                foreach (var item in carrinhoDeCompra.Items)
                {
                    adicionarItemDoPedido(novoPedido, item);
                }

                pedidoRepositorio.Salvar(novoPedido);
                return novoPedido;

            }
            return new Pedido();
        }

        private void adicionarItemDoPedido(Pedido pedido, ItemDoCarrinho item)
        {
            var itemPedido = new ItemPedido
             {
                 Curso = item.Curso,
                 ValorPago = item.ValorUnitario,
                 Quantidade = item.Quantidade,
             };

            itemPedidoRepositorio.Salvar(itemPedido);
        }
        private bool ValidaSeTemEstoque(CarrinhoDeCompra carrinhoDeCompra)
        {
            foreach (var item in carrinhoDeCompra.Items)
            {
                var curso = cursoRepositorio.Recuperar(item.Curso.Id);
                if (curso.QuantidadeEstoque == 0)
                    return false;
            }
            return true;
        }
    }
}
