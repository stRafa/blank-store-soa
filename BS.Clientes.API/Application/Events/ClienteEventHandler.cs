﻿using MediatR;

namespace BS.Clientes.API.Application.Events
{
    public class ClienteEventHandler : INotificationHandler<ClienteRegistradoEvent>
    {
        public Task Handle(ClienteRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;       
        }
    }
}
