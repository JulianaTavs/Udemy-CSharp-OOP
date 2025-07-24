using System.Globalization;
using Ex32;

List<Produtos> list = new List<Produtos>();
ValidatingData validatingData = new ValidatingData();

Console.WriteLine("Quantos produtos você quer adicinar à lista?");
int numeroDeProdutos = validatingData.GetAValidInt();

for (int i = 0; i < numeroDeProdutos; i++)
{
    Console.WriteLine("Qual o nome do produto: ");
    string nome = validatingData.GetAValidString();

    Console.WriteLine("Qual o valor do produto: ");
    decimal preco = validatingData.GetAValidDecimal();

    Produtos produto = new Produtos(nome, preco);
    list.Add(produto);
}
list.Sort();

CalculationService calculationService = new CalculationService();

if (list.Count > 0)
{
    Console.WriteLine("Produto mais caro: ");
    Console.WriteLine(calculationService.Max(list));
}
else
{
    Console.WriteLine("Lista vazia!");
}

