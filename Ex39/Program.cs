using System.Globalization;
using Ex39.Entities;
string path = @"D:\Udemy CSharp & OOP\Ex39\arquivo.txt";

List<Product> products = new List<Product>();

try
{
    using (StreamReader sr = File.OpenText(path))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] parts = line.Split(',');

            if (parts.Length == 5)
            {
                string nome = parts[0].Trim();
                int id = int.Parse(parts[1].Trim());
                double price = double.Parse(parts[2].Trim(), CultureInfo.InvariantCulture);

                string categoryName = parts[3].Trim();
                int categoryTier = int.Parse(parts[4].Trim());

                Category category = new Category(categoryName, categoryTier);

                products.Add(new Product(nome, id, price, category));
            }
            else
            {
                Console.WriteLine($"Linha descartada por não possuir os cinco atributos do produto: {line}");
                continue;
            }

        }
    }

    Console.WriteLine("\n--- PRODUTOS LIDOS COM SUCESSO ---\n");
    foreach (Product p in products)
    {
        Console.WriteLine(p);
    }

    Console.Write("\nPREÇO MÉDIO DOS PRODUTOS: ");
    var mediaPreco = products.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
    // var mediaPreco = products.Average(p => p.Price); <-- Só usar essa versão quando você tem certeza (por meio de validações anteriores) de que a lista nunca estará vazia.
    Console.WriteLine(mediaPreco.ToString("F2", CultureInfo.InvariantCulture));

    Console.WriteLine("PREÇOS DOS PRODUTOS, COM VALOR INFERIOR AO PREÇO MÉDIO, EM ORDEM DECRESCENTE: ");
    var ordemDecrescente = products.Where(p => p.Price < mediaPreco).OrderByDescending(p => p.Name);

    foreach (var p in ordemDecrescente)
    {
        Console.WriteLine(p.Name);
    }
    
}
catch (IOException ex)
{
    Console.WriteLine("\n--- ERRO DE I/O ---");
    Console.WriteLine(ex.Message);
    Console.WriteLine("Verifique se o arquivo.txt existe no caminho especificado.");
}
catch (FormatException ex)
{
    Console.WriteLine("\n--- ERRO DE FORMATO ---");
    Console.WriteLine(ex.Message);
    Console.WriteLine("Verifique se os IDs e Preços estão nos formatos corretos (ex: 123, 49.99).");
}




