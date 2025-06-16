using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex24
{
    class GettingDataValidated
    {
        public int GetAValidInt(string message)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
        }
        public TypeOfTaxPayer GetAValidTaxPayer()
        {
            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please enter 'i' for individual or 'c' for company.");
                    continue;
                }

                // If input is not empty, get the first char
                char inputChar = input[0];

                switch (inputChar)
                {
                    case 'i':
                        {
                            return TypeOfTaxPayer.Individual;
                        }
                    case 'c':
                        {
                            return TypeOfTaxPayer.Company;
                        }
                    default:
                        Console.WriteLine("Invalid input. Please enter only i for individual " +
                            "OR c for company: ");
                        break;
                }
            }
        }
        public string GetAValidName()
        {
            while (true)
            {
                string name = Console.ReadLine().Trim();
                /* Regex: Matches any character that is NOT a letter, number,
                & . , - ' ( ) / or space.
                If IsMatch returns true, it means an INVALID character was found. */

                // A condição agora verifica:
                // 1. Se o nome NÃO está vazio ou contém apenas espaços em branco.
                // 2. E se o nome NÃO contém NENHUM caractere inválido (ou seja, Regex.IsMatch retorna false).
                if (!string.IsNullOrWhiteSpace(name) &&
                !Regex.IsMatch(name, "[^A-Za-zÀ-ÖØ-öø-ÿ0-9&.,\\-'()/ ]"))
                {
                    return name;
                }
                else
                {
                    // Se a validação falhar, informa o usuário e continua o loop
                    Console.WriteLine("Invalid name. Please use only letters, numbers, spaces, hyphens, " +
                    "apostrophes, and common symbols like & . , ( ) /");
                }
            }
        }
        public decimal GetAValidDecimal(string message)
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(),
                CultureInfo.CreateSpecificCulture("en-US"),
                out decimal output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}