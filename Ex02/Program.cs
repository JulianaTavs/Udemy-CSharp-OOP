using System.Globalization;

Console.Clear();
Console.WriteLine("Digite o valor do raio do círculo: ");
double raio = LerRaio();
const double π = 3.14159;
double area = π * Math.Pow(raio, 2);

System.Console.WriteLine($"Área: {area.ToString("F4", CultureInfo.InvariantCulture)}");

static double LerRaio()
{
    while (true)
    {
        string entrada = Console.ReadLine();


        // Garantir que o valor seja aceito tanto com ponto quanto com vírgula

        entrada = entrada.Replace(",", ".");// Substitui vírgula por ponto

        if (double.TryParse(entrada, CultureInfo.InvariantCulture, out double numero) && numero > 0)
        {
            return numero;
        }
        else
        {
            Console.WriteLine("Valor inválido. O valor do raio deve ser um número positivo. Tente novamente: ");
        }
    }
}
