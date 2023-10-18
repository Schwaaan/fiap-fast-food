﻿using FourSix.Domain.Entities.ClienteAggregate;

namespace FourSix.WebApi.ViewModels
{
    public class ClienteModel
    {
        public ClienteModel(Cliente cliente)
        {
            Id = cliente.Id;
            Cpf = cliente.Cpf;
            Nome = cliente.Nome;
            Email = cliente.Email;
        }
        public Guid Id { get; set; }
        public string Cpf { get; }
        public string Nome { get; }
        public string Email { get; }
    }
}
