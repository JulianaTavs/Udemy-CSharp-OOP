Console.WriteLine("Entre com a ordem da matriz: ");

int N = int.Parse(Console.ReadLine());

int[,] matriz = new int[N, N];

for (int i = 0; i < N; i++)
{
    Console.WriteLine($"Digite os números da {i + 1}ª linha da matriz: ");
    string[] values = Console.ReadLine().Split(',');

    for (int j = 0; j < N; j++)
    {
        matriz[i, j] = int.Parse(values[j]);
    }
}

Console.WriteLine("------------------------------------");
Console.WriteLine("Main diagonal: ");
for (int i = 0; i < N; i++)
{
    Console.Write(matriz[i, i] + " ");
}

Console.WriteLine();
int contador = 0;

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (matriz[i, j] < 0)
        {
            contador++;
        }
    }
}

Console.WriteLine($"Qtde de números negativos na matriz: {contador}");