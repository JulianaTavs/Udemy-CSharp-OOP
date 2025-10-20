
string path = @"D:\Udemy CSharp & OOP\Ex36\dadosVotacao.txt";

Dictionary<string, int> dictionary = new Dictionary<string, int>();

try
{
    using (StreamReader sr = File.OpenText(path))
    {
        while (!sr.EndOfStream)
        {
            string[] partesDaLinha = sr.ReadLine().Split(',');
            string candidato = partesDaLinha[0];
            int votos = int.Parse(partesDaLinha[1]);

            if (dictionary.ContainsKey(candidato))
            {
                dictionary[candidato] += votos;
            }
            else
            {
                dictionary[candidato] = votos;
            }
        }
    }

    foreach (var item in dictionary)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
}
catch (IOException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}