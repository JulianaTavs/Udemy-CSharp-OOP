using System.Globalization;
using Ex10;

decimal ValorEmReais = ConversorDeMoeda.PagamentoEmReais();

Console.WriteLine($"Valor a ser pago em reais: {ValorEmReais.ToString("F2",
CultureInfo.InvariantCulture)}");

