using System.Globalization;
using Ex06;

Funcionario funcionario1 = new Funcionario();
Funcionario funcionario2 = new Funcionario();

Console.WriteLine("Digite o nome do funcionário 1: ");
funcionario1.Nome = Console.ReadLine();
Console.WriteLine("Digite o salário do funcionário 1:");
funcionario1.Salario = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Console.WriteLine("Digite o nome do funcionário 2: ");
funcionario2.Nome = Console.ReadLine();
Console.WriteLine("Digite o salário do funcionário 2:");
funcionario2.Salario = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Nome do funcionário 1: {funcionario1.Nome}");
Console.WriteLine($"Salário do funcionário 1: {funcionario1.Salario}");
Console.WriteLine("--------------------------------------------");
Console.WriteLine($"Nome do funcionário 2: {funcionario2.Nome}");
Console.WriteLine($"Salário do funcionário 2: {funcionario2.Salario}");
Console.WriteLine("--------------------------------------------");

decimal mediaSalario = (funcionario1.Salario + funcionario2.Salario) / 2;
Console.WriteLine($"Média salarial: {mediaSalario:C}");