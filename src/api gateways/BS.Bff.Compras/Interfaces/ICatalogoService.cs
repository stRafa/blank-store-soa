using BS.Compras.BFF.Models;

namespace BS.Compras.BFF.Interfaces
{
    public interface ICatalogoService
    {
        Task<ItemProdutoDTO> ObterPorId(Guid id);
    }
}