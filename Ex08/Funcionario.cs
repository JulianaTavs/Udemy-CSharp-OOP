using System.Text.RegularExpressions;

namespace Ex08
{
    public class Funcionario
    {
        public string Nome;
        public double SalarioBruto;
        public double Imposto;

        public Funcionario()
        {
            Nome = ValidarNome();
            SalarioBruto = ValidarSalarioBruto();
            Imposto = ValidarImposto();
        }

        public string ValidarNome()
        {
            Console.WriteLine("Digite seu nome: ");
            while (true)
            {
                string nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, "^[\\p{L}\\s]+$"))
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar um nome válido: ");
                }
            }
        }

        public double ValidarSalarioBruto()
        {
            Console.WriteLine("Digite seu salário bruto: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente seu salário bruto: ");
                }
            }
        }

        public double ValidarImposto()
        {
            Console.WriteLine("Digite quanto você paga de imposto: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente o valor do imposto: ");
                }
            }
        }

        public double SalarioLiquido()
        {
            double salarioLiquido = SalarioBruto - Imposto;

            return salarioLiquido;
        }

        public void AumentarSalario(double porcentagem)
        {
            SalarioBruto += SalarioBruto * (porcentagem / 100);
        }
    }
}