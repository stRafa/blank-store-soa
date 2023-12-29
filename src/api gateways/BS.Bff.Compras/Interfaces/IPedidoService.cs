using BS.Compras.BFF.Models;

namespace BS.Compras.BFF.Interfaces
{
    public interface IPedidoService
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }
}