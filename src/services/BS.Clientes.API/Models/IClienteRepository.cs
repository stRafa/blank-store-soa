using BS.Core.Data;

namespace BS.Clientes.API.Models
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterPorCpf(string cpf);
        Task<Cliente> ObterPorId(Guid id);

        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
    }
}
