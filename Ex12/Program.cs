using Ex12;

Quarto[] quarto = new Quarto[10];

Console.WriteLine("Temos 10 quartos no pensionato. Quantos quartos serão alugados? ");

int N;
while (true)
{
    if (int.TryParse(Console.ReadLine(), out int inteiro) && inteiro > 0 && inteiro <= 10)
    {
        N = inteiro;
        break;
    }
}

int numeroQuarto;

Console.WriteLine("Os quartos são numerados de 0 a 9.");
int i = 1;
while (i <= N)
{
    Console.WriteLine(i + "ª" + " pessoa:");
    numeroQuarto = Quarto.LerQuarto();
    quarto[numeroQuarto] = new Quarto(); // Inicializa o quarto escolhido pela pessoa.
    i++;
}

Console.WriteLine("\nLista dos quartos alugados:");

i = 0;
while (i < quarto.Length)
{
    if (quarto[i] != null) // Só imprime os quartos inicializados.
    {
        Console.WriteLine($"Quarto {i}: " + quarto[i]);
    }
    i++;
}


