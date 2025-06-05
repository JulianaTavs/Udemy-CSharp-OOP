using System.Text.RegularExpressions;

namespace Ex12
{
    class Quarto
    {
        public string Nome;
        public string Email;
        public Quarto()
        {
            Nome = LerNome();
            Email = LerEmail();
        }
        public string LerNome()
        {
            Console.WriteLine("Digite seu nome: ");

            while (true)
            {
                string nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, @"^[\p{L}]+(?:[\s][\p{L}]+)*$"))
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente seu nome: ");
                }
            }
        }

        public string LerEmail()
        {
            Console.WriteLine("Digite seu email: ");
            while (true)
            {
                string email = Console.ReadLine();
                if (Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))

                    return email;
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente seu email:");
                }
            }
        }
        public static int LerQuarto()
        {
            Console.WriteLine("Qual quarto você deseja alugar?");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int numero) && numero >= 0 && numero <= 9)
                {
                    return numero;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar um número entre 0 e 9: ");
                }
            }
        }
        public override string ToString()
        {
            return "Nome: " + Nome + "; " +
                   "Email: " + Email;
        }
    }
}