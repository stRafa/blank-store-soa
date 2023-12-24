using FluentValidation;

namespace BS.Clientes.API.Application.Commands.Validations
{
    public class RegistrarClienteValidation : AbstractValidator<RegistrarClienteCommand>
    {
        public RegistrarClienteValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("O nome do cliente não foi informado");

            RuleFor(c => c.Cpf)
                .Must(TerCpfValido)
                .WithMessage("O CPF informado não é válido");

            RuleFor(c => c.Email)
                .Must(TerEmailValido)
                .WithMessage("O e-mail informado não é válido");
        }
        protected static bool TerCpfValido(string cpf)
        {
            return Core.DomainObjects.Cpf.Validar(cpf);
        }

        protected static bool TerEmailValido(string email)
        {
            return Core.DomainObjects.Email.Validar(email);
        }
    }
}
