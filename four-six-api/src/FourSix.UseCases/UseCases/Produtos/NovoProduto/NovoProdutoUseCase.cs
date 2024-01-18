using FourSix.Domain.Entities.ProdutoAggregate;
using FourSix.UseCases.Interfaces;

namespace FourSix.UseCases.UseCases.Produtos.NovoProduto
{
    public class NovoProdutoUseCase : INovoProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NovoProdutoUseCase(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork)
        {
            this._produtoRepository = produtoRepository;
            this._unitOfWork = unitOfWork;
        }

        public Task Execute(string nome, string descricao, EnumCategoriaProduto categoria, decimal preco) =>
            this.NovoProduto(new Produto(Guid.NewGuid(),
                nome,
                descricao,
                categoria,
                preco,
                true));

        private async Task NovoProduto(Produto produto)
        {
            if (this._produtoRepository
                .Listar(q => q.Nome == produto.Nome
                && q.Categoria == produto.Categoria).Any())
            {
                throw new Exception("Produto j� existe com esse nome e categoria");
            }

            await this._produtoRepository
                 .Incluir(produto)
                 .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
