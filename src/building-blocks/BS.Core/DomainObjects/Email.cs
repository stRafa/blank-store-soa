using System.Text.RegularExpressions;

namespace BS.Core.DomainObjects
{
    public class Email
    {
        public const int EnderecoMaxLength = 254;
        public const int EnderecoMinLength = 5;
        public string Endereco { get; private set; }
        // EF Relation
        protected Email() { }
        public Email(string endereco)
        {
            if (!Validar(endereco)) throw new DomainException("E-mail inválido");
            Endereco = endereco;
        }
        public static bool Validar(string email)
        {
            var regexEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regexEmail.IsMatch(email);
        }
    }
}
