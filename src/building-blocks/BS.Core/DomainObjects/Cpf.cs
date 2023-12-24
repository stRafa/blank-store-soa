using BS.Core.Utils;

namespace BS.Core.DomainObjects
{
    public class Cpf
    {
        public const int CpfMaxLength = 11;
        public string Numero { get; private set; }
        // EF Relation
        protected Cpf() { }
        public Cpf(string numero)
        {
            if (!Validar(numero)) throw new DomainException("CPF inválido");
            Numero = numero;
        }

        public static bool Validar(string cpf)
        {
            var multiplicador1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim().Replace(".", "").Replace("-", "").ApenasNumeros();
            if (cpf.Length != CpfMaxLength)
                return false;
            var tempCpf = cpf.Substring(0, CpfMaxLength - 2);
            var soma = 0;
            for (var i = 0; i < CpfMaxLength - 2; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            var digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (var i = 0; i < CpfMaxLength - 1; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto;
            return cpf.EndsWith(digito);
        }
    }
}
