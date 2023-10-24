﻿using FourSix.Domain.Entities.ClienteAggregate;
using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Domain.Entities.PedidoAggregate
{
    public class Pedido : BaseEntity, IAggregateRoot, IBaseEntity
    {
        private readonly List<PedidoItem> _pedidoItens;
        private readonly List<PedidoStatus> _pedidoStatus;

        public Pedido() { }

        public Pedido(Guid id, string numeroPedido, DateTime dataPedido, Guid? clienteId)
        {
            Id = id;
            NumeroPedido = numeroPedido;
            DataPedido = dataPedido;
            ClienteId = clienteId;
        }

        public string NumeroPedido { get; }
        public Guid? ClienteId { get; }
        public DateTime DataPedido { get; }
        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens.AsReadOnly();
        public IReadOnlyCollection<PedidoStatus> PedidoStatus => _pedidoStatus.AsReadOnly();
        public int TotalItens => _pedidoItens.Sum(i => i.Quantidade);
        public decimal ValorTotal => _pedidoItens.Sum(i => i.ValorUnitario * i.Quantidade);
        public Cliente Cliente { get; set; }

        public void AdicionarItem(Produto produto, decimal valorUnitario, int quantidade = 1, string? observacao = null)
        {
            if (!PedidoItens.Any(i => i.ItemPedido.Id == produto.Id))
            {
                _pedidoItens.Add(new PedidoItem(Id, produto.Id, valorUnitario, quantidade, observacao));
                return;
            }
            var itemExistente = PedidoItens.First(i => i.ItemPedido.Id == produto.Id);
            itemExistente.AdicionarQuantidade(quantidade);
        }

        public void AlterarStatus(EnumStatus statusId, DateTime dataStatus)
        {
            _pedidoStatus.Add(new PedidoStatus(Id, statusId, dataStatus));
        }
    }
}
