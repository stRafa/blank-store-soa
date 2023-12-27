using BS.Compras.BFF.Models;
using BS.Core.Communication;

namespace BS.Compras.BFF.Interfaces
{
    public interface ICarrinhoService
    {
        Task<CarrinhoDTO> ObterCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoDTO produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoDTO produto);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
    }
}