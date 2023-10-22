﻿using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Application.UseCases.Produtos.ObtemProdutoPorTipo
{
    public interface IOutputPort
    {
        void Invalid();
        void NotFound();
        void Ok(Produto produtos);
    }
}