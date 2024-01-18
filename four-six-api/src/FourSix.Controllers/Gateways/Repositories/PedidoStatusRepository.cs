﻿using FourSix.Domain.Entities.PedidoAggregate;
using FourSix.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FourSix.Controllers.Gateways.Repositories
{
    public class PedidoStatusRepository : BaseRepository<PedidoCheckout, EnumStatusPedido>, IPedidoCheckoutRepository
    {
        public PedidoStatusRepository(DbContext context) : base(context)
        {
        }
    }
}
