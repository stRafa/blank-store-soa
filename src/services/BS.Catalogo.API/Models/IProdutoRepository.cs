using BS.Core.Data;

namespace BS.Catalogo.API.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
