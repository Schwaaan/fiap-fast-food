﻿using FourSix.Application.Services;
using FourSix.Application.UseCases.Clientes.NovoCliente;
using FourSix.Application.UseCases.Clientes.ObtemCliente;

namespace FourSix.WebApi.Modules
{
    public static class UseCasesExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Notification, Notification>();

            services.AddScoped<INovoClienteUseCase, NovoClienteUseCase>();
            services.Decorate<INovoClienteUseCase, NovoClienteValidationUseCase>();

            services.AddScoped<IObtemClienteUseCase, ObtemClienteUseCase>();
            services.Decorate<IObtemClienteUseCase, ObtemClienteValidationUseCase>();

            return services;
        }
    }
}
