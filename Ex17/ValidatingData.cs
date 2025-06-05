using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex17
{
    public class ValidatingData
    {
        public string GetAValidName()
        {
            while (true)
            {
                Console.Write("Name: ");
                string name = Console.ReadLine()!.Trim();

                if (!string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[\p{L}\s'-]+$"))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente o nome do depto: ");
                }
            }
        }

        public WorkerLevel GetAValidLevel()
        {
            while (true)
            {
                Console.Write("Level(Junior, MidLevel, Senior): ");
                string level = Console.ReadLine()!.Trim().ToUpper();

                if (Enum.TryParse<WorkerLevel>(level, out WorkerLevel workerLevel))
                {
                    return workerLevel;
                }
                else
                {
                    Console.WriteLine("Nível inválido. Favor digitar novamente o nível (Junior, MidLevel, Senior): ");
                }
            }
        }

        public double GetAValidBaseSalary()
        {
            while (true)
            {
                Console.WriteLine("Base salary: ");
                if (double.TryParse(Console.ReadLine(), out double saida) && saida > 0)
                {
                    return saida;
                }
                else
                {
                    Console.WriteLine("Salário base inválido. Favor digitar um salário base "
                    + "maior que zero: ");
                }
            }
        }

        public int GetNumberOfContracts()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int saida) && saida > 0)
                {
                    return saida;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar qts contratos você tem: ");
                }
            }
        }

        public DateTime GetAValidDateTime()
        {
            Console.WriteLine("Enter contract date(dd/MM/yyyy): ");
            CultureInfo culture = new CultureInfo("pt-BR");
            string format = "dd/MM/yyyy";  // The exact format we expect

            while (true)
            {
                if (DateTime.TryParseExact(Console.ReadLine(), format, culture, DateTimeStyles.None, out DateTime contractDate))
                {
                    return contractDate;
                }
                else
                {
                    Console.WriteLine("Formato de data inválido. "
                    + "Digite a data no formato dd/MM/yyyy (ex: 21/08/2024)");
                }
            }
        }


        public double GetAValidValuePerHour()
        {
            Console.WriteLine("Value per hour: ");

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double saida) && saida > 0)
                {
                    return Math.Round(saida, 2);
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar o salário por hora corretamente: ");
                }
            }
        }

        public int GetValidHours()
        {
            Console.WriteLine("Duration(hours): ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int saida) && saida > 0)
                {
                    return saida;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar o nº de horas exato"
                    + "trabalhadas durante o contrato: ");
                }
            }
        }

        public (int, int) MonthAndYear()
        {
            Console.Write("Digite o mês e o ano que você deseja saber " +
            "quanto de salário você ganhou(MM/yyyy): ");

            int month;
            int year;

            while (true)
            {
                string monthAndYear = Console.ReadLine()!;

                if (int.TryParse(monthAndYear.Substring(0, 2), out month) &&
                    int.TryParse(monthAndYear.Substring(3), out year))
                {
                    return (month, year);
                }
                else
                {
                    Console.WriteLine("Favor digitar o mês e o ano no seguinte formato MM/yyyy :");
                }
            }
        }
    }
}