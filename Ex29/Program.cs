string path = @"D:\Udemy CSharp & OOP\meuarquivo.txt";

try
{
    using (StreamReader sr = File.OpenText(path))
    {
        List<string> lista = new List<string>();
        while (!sr.EndOfStream)
        {
            lista.Add(sr.ReadLine());
        }

        lista.Sort();

        foreach (string linha in lista)
        {
            Console.WriteLine(linha);
        }
    }
}
catch (IOException e)
{
    Console.WriteLine("An error occurred.");
    Console.WriteLine(e.Message);
}


