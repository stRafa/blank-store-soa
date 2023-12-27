using BS.Core.Data;
using BS.Pedidos.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;

namespace BS.Pedidos.Infra.Data.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(c => c.Codigo == codigo);
        }
    }
}
