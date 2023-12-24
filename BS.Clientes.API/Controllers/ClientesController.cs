using BS.Clientes.API.Application.Commands;
using BS.Clientes.API.Models;
using BS.Core.Mediator;
using BS.Identidade.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BS.Clientes.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(new RegistrarClienteCommand(Guid.NewGuid(), "Rafael", "rafael@rafael.com", "42022125096"));

            return CustomResponse(resultado);
        }
    }
}
