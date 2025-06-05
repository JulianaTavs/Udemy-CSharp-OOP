using System.Globalization;

Console.WriteLine("Digite o ID do funcionário: ");
int id = LerIdEHoras();

int horasTrabalhadas = LerIdEHoras();

Console.WriteLine("Digite o valor da hora trabalhada(ex: 15,50 ou 15.50): ");
decimal valorHora = LerValorHora();

decimal salario = horasTrabalhadas * valorHora;

System.Console.WriteLine($"NUMBER = {id}");
System.Console.WriteLine($"SALARY = U$ {salario.ToString("F2", CultureInfo.InvariantCulture)}");

static int LerIdEHoras()
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            return numero;
        }
        else
        {
            System.Console.WriteLine("Valor inválido. Favor digitar um valor inteiro: ");
        }
    }
}

static decimal LerValorHora()
{
    while (true)
    {
        string data = Console.ReadLine();

        data = data.Replace(',', '.');
        if (decimal.TryParse(data, CultureInfo.InvariantCulture, out decimal valor))
        {
            return valor;
        }
        else
        {
            System.Console.WriteLine("Valor inválido. Favor digitar o valor da hora trabalhada novamente: ");
        }
    }
}