using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BS.Identidade.API.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class MainController : ControllerBase
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object resull = null)
        {
            if (OperacaoValida()) return Ok(resull);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Mensagens", Erros.ToArray() },
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            foreach (var erro in modelState.Values.SelectMany(e => e.Errors))
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult AdicionarErroProcessamento(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool OperacaoValida() => Erros.Count == 0;

        protected void AdicionarErroProcessamento(string erro) => Erros.Add(erro);

        protected void AdicionarErroProcessamento(Exception erro) => Erros.Add(erro.Message);

        protected void LimparErrosProcessamento() => Erros.Clear();
        
    }
}
