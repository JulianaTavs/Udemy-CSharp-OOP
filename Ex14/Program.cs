int[,] matriz = {
    {1, -2, 3},
    {4, 5, -6},
    {7, 8, -9}
};

MostrarDiagonalPrincipal(matriz);

static void MostrarDiagonalPrincipal(int[,] matriz)
{
    int N = matriz.GetLength(0);
    int contadorNegativos = 0;
    Console.WriteLine("Diagonal principal: ");

    for (int i = 0; i < N; i++)
    {
        Console.Write(matriz[i, i] + " ");
    }

    Console.WriteLine();

    foreach (var item in matriz)
    {
        if (item < 0)
        {
            contadorNegativos++;
        }
    }
    Console.WriteLine($"Qtde de valores negativos da matriz: {contadorNegativos}");
}


