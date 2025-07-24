using System.Globalization;

namespace Ex32ResolvendoComRestricaoDeGenericos
{
    public class ValidatingData
    {
        public decimal GetAValidDecimal()
        {
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture,
                out decimal output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Dado inválido. Favor entrar com um preço utilizando o " +
                    "seguinte separador de decimais '.'(Ex: 810.15): ");
                }
            }
        }

        public string GetAValidString()
        {
            while (true)
            {
                string nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome))
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("O campo nome não pode estar nulo ou em branco. " +
                    "Favor digitar um nome: ");
                }
            }
        }
        public int GetAValidInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Dado inválido. Favor digitar um número inteiro maior " +
                    "que zero: ");
                }
            }
        }
    }
}