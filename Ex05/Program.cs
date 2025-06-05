using Ex05;

Pessoa pessoa1 = new Pessoa();
Pessoa pessoa2 = new Pessoa();

Console.WriteLine("Entre com o nome da pessoa 1:");
pessoa1.Nome = Console.ReadLine();
Console.WriteLine("Entre com a idade da pessoa 1:");
pessoa1.Idade = int.Parse(Console.ReadLine());

Console.WriteLine("Entre com o nome da pessoa 2:");
pessoa2.Nome = Console.ReadLine();
Console.WriteLine("Entre com a idade da pessoa 2:");
pessoa2.Idade = int.Parse(Console.ReadLine());

Console.WriteLine("-------------------------------------------");
Console.WriteLine($"Nome da primeira pessoa: {pessoa1.Nome}");
Console.WriteLine($"Idade da primeira pessoa: {pessoa1.Idade}");
Console.WriteLine("-------------------------------------------");
Console.WriteLine($"Nome da segunda pessoa: {pessoa2.Nome}");
Console.WriteLine($"Idade da segunda pessoa: {pessoa2.Idade}");
Console.WriteLine("-------------------------------------------");

if (pessoa1.Idade > pessoa2.Idade)
{
    Console.WriteLine($"Pessoa mais velha: {pessoa1.Nome} ");
}
else
{
    Console.WriteLine($"Pessoa mais velha: {pessoa2.Nome}");
}
Console.WriteLine("-------------------------------------------");