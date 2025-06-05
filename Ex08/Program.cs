using System.Globalization;
using Ex08;

Funcionario funcionario = new Funcionario();

Console.WriteLine($"Funcionário: {funcionario.Nome}, " +
$"{funcionario.SalarioLiquido().ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");

Console.WriteLine("Digite a porcentagem para aumentar o salário:");

while (true)
{
    if (double.TryParse(Console.ReadLine(), out double porcentagem) && porcentagem > 0 &&
    porcentagem <= 100)
    {
        funcionario.AumentarSalario(porcentagem);
        break;
    }
    else
    {
        Console.WriteLine("Valor inválido. Favor digitar novamente a porcentagem entre 0 a 100: ");
    }
}

Console.WriteLine($"Funcionário: {funcionario.Nome}, " +
$"{funcionario.SalarioLiquido().ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
