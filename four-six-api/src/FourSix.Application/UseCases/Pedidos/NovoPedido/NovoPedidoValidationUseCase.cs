﻿using FourSix.Application.Services;

namespace FourSix.Application.UseCases.Pedidos.NovoPedido
{
    public class NovoPedidoValidationUseCase : INovoPedidoUseCase
    {
        private readonly Notification _notification;
        private readonly INovoPedidoUseCase _useCase;
        private IOutputPort _outputPort;

        public NovoPedidoValidationUseCase(INovoPedidoUseCase useCase, Notification notification)
        {
            this._useCase = useCase;
            this._notification = notification;
            this._outputPort = new NovoPedidoPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            this._outputPort = outputPort;
            this._useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(string numeroPedido, DateTime dataPedido, Guid? clienteId)
        {
            if (string.IsNullOrEmpty(numeroPedido))
                this._notification
                    .Add(nameof(numeroPedido), $"{nameof(numeroPedido)} é obrigatório.");

            if (this._notification
            .IsInvalid)
            {
                this._outputPort
                    .Invalid();
                return;
            }

            await this._useCase
                .Execute(numeroPedido, dataPedido, clienteId)
                .ConfigureAwait(false);
        }
    }
}
