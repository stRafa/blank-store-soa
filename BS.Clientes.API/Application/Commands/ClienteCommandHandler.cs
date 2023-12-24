using BS.Clientes.API.Application.Events;
using BS.Clientes.API.Models;
using BS.Core.Messages;
using FluentValidation.Results;
using MediatR;

namespace BS.Clientes.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            // Validacoes de negocio
            var clienteExistente = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);

            if (clienteExistente != null)
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            _clienteRepository.Adicionar(cliente);

            cliente.AdicionarEvento(new ClienteRegistradoEvent(message.Id, message.Nome, message.Email, message.Cpf));

            return await PersistirDados(_clienteRepository.UnitOfWork);
        }
    }
}
