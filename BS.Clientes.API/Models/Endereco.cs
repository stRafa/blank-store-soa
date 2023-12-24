using BS.Core.DomainObjects;

namespace BS.Clientes.API.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Endereco(string logradouro, string numero, string complemento, string cep, string bairro, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

    }
}
