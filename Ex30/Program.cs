string path = @"D:\Udemy CSharp & OOP\Ex30\funcionarios.csv";

try
{
    using (StreamReader sr = File.OpenText(path))
    {
        List<string> list = new List<string>();

        while (!sr.EndOfStream)
        {
            list.Add(sr.ReadLine());
        }

        list.Sort();

        foreach (string line in list)
        {
            Console.WriteLine(line);
        }
    }
}
catch (IOException e)
{
    Console.WriteLine("An exception has occurred!");
    Console.WriteLine(e.Message);
}

