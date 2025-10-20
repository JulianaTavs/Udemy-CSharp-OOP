using System.Globalization;
using Ex40;

string path = @"D:\Udemy CSharp & OOP\Ex40\arquivo.txt";

List<Funcionario> funcionarios = new List<Funcionario>();
double salarioFornecido = 0.0;

try
{
    using (StreamReader sr = File.OpenText(path))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            string[] parts = line.Split(',');

            if (parts.Length == 3)
            {
                string nome = parts[0];
                string email = parts[1];
                double salario = double.Parse(parts[2], CultureInfo.InvariantCulture);

                funcionarios.Add(new Funcionario(nome, email, salario));
            }
        }
    }

    Console.Write("Digite o valor mínimo de salário dos funcionários que você deseja ver os emails" +
    " em ordem alfabética: R$ ");

    while (true)
    {
        if (double.TryParse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture, out salarioFornecido))
        {
            break;
        }

        Console.WriteLine("\nAviso: Entrada inválida. Digite um valor de salário válido. (Ex: 2000,00): ");
        Console.Write("R$ ");
    }

    var listaDeEmails = funcionarios
       .Where(f => f.Salary > salarioFornecido)
       .OrderBy(f => f.Email)
       .Select(f => f.Email);

    Console.WriteLine("\nEMAILS FILTRADOS:");
    if (!listaDeEmails.Any())
    {
        Console.WriteLine("(Nenhum e-mail encontrado acima do salário mínimo)");
    }

    foreach (var f in listaDeEmails)
    {
        Console.WriteLine(f);
    }

    var somaSalarios = funcionarios
    .Where(f => f.Name.StartsWith('M'))
    .Sum(f => f.Salary);

    Console.WriteLine("Soma dos salários dos funcionários os quais o nome comece" +
    $" com a letra 'M': R$ {somaSalarios.ToString("F2", CultureInfo.InvariantCulture)}");

}
catch (IOException ex)
{
    Console.WriteLine($"Erro de entrada:  Não foi possível ler o arquivo. {ex.Message}");
}
catch (Exception ex)
{
    // Captura qualquer outro erro que possa surgir, como a falta de definição de Funcionario.
    Console.WriteLine($"\nOcorreu um erro inesperado: {ex.Message}");
}
