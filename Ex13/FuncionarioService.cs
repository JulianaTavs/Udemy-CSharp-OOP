using System.Text.RegularExpressions;

namespace Ex13
{
    class FuncionarioService
    {
        public int ObterId()
        {
            Console.WriteLine("Digite o ID do funcionário:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int saida) && saida > 0)
                {
                    return saida;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar seu id novamente: ");
                }
            }
        }
        public decimal ObterSalario()
        {
            Console.WriteLine("Digite o salário do funcionário:");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal saida) && saida > 0)
                {
                    return saida;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar seu salário novamente: ");
                }
            }
        }
        public string ObterNome()
        {
            Console.WriteLine("Digite o nome do funcionário: ");
            while (true)
            {
                string nome = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, @"^[\p{L}\s'-]+$"))
                // O Regex acima permitirá letras, espaços, apóstrofos e hífens, o que pode 
                // ser mais adequado para nomes.
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente o nome: ");
                }
            }
        }
    }
}