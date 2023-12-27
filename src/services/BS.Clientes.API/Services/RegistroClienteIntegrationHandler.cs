
using BS.Clientes.API.Application.Commands;
using BS.Core.Mediator;
using BS.Core.Messages.Integration;
using BS.MessageBus;
using EasyNetQ;
using FluentValidation.Results;

namespace BS.Clientes.API.Services
{
    public class RegistroClienteIntegrationHandler(IServiceProvider serviceProvider, IMessageBus bus) : BackgroundService
    {

        private IMessageBus _bus = bus;
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        private void SetResponder()
        {
            _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(RegistrarCliente);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();

            _bus.AdvancedBus.Connected += OnConnect;

            return Task.CompletedTask;
        }

        private void OnConnect(object? sender, EventArgs e)
        {
            SetResponder();
        }

        private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
        {
            var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(clienteCommand);
            }

            return new ResponseMessage(sucesso);
        }
    }
}
