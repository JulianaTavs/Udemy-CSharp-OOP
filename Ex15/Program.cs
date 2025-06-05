Console.WriteLine("Digite quantas linhas haverão na matriz: ");
int M = ValidarInteiro("Valor inválido. Favor digitar novamente o número de linhas: ");

Console.WriteLine("Digite quantas colunas haverão na matriz: ");
int N = ValidarInteiro("Valor inválido. Favor digitar novamente o número de colunas: ");

int[,] matriz = new int[M, N];

static int ValidarInteiro(string mensagem)
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int saida) && saida > 0)
        {
            return saida;
        }
        else
        {
            Console.WriteLine(mensagem);
        }
    }
}
for (int i = 0; i < M; i++)
{
    Console.WriteLine($"Digite os números da {i + 1}ª linha da matriz: ");
    string[] row = Console.ReadLine().Trim().Split(',');

    for (int j = 0; j < N; j++)
    {
        matriz[i, j] = int.Parse(row[j]);
    }
}

Console.WriteLine();

for (int i = 0; i < M; i++)
{
    for (int j = 0; j < N; j++)
    {
        Console.Write(matriz[i, j] + " ");
    }
    Console.WriteLine();
}

int X = ValidarNumeroEscolhidoDaMatriz();

int ValidarNumeroEscolhidoDaMatriz()
{
    Console.WriteLine("Qual número da matriz você deseja escolher?");
    while (true)
    {
        Console.WriteLine("Digite um número que exista na matriz: ");
        if (int.TryParse(Console.ReadLine(), out int saida))
        {
            foreach (var item in matriz)
            {
                if (saida == item)
                {
                    return saida;
                }
            }
        }
        else
        {
            Console.WriteLine("Valor inválido. Favor escolher um dos números que a matriz possui: ");
        }
    }
}

(int linha, int coluna) EncontrarPosicaoNaMatriz(int numeroEscolhido)
{
    for (int i = 0; i < matriz.GetLength(0); i++) // Percorre as linhas
    {
        for (int j = 0; j < matriz.GetLength(1); j++) // Percorre as colunas
        {
            if (matriz[i, j] == numeroEscolhido)
            {
                return (i, j); // Retorna a posição (linha, coluna)
            }
        }
    }
    return (-1, -1); // Retorna (-1, -1) se o número não for encontrado
}
var (linha, coluna) = EncontrarPosicaoNaMatriz(X);
Console.WriteLine($"Número encontrado na posição: Linha {linha}, Coluna {coluna}");

void MostrarVizinhos(int numeroEscolhido)
{
    var (linha, coluna) = EncontrarPosicaoNaMatriz(numeroEscolhido);

    if (linha == -1 || coluna == -1)
    {
        Console.WriteLine("Número não encontrado na matriz.");
        return;
    }

    // Exibir os vizinhos
    Console.WriteLine($"Vizinhos de {numeroEscolhido} (Posição: {linha},{coluna}):");

    // Acima
    if (linha > 0)
        Console.WriteLine($"Acima: {matriz[linha - 1, coluna]}");
    else
        Console.WriteLine("Acima: Não existe.");

    // Abaixo
    if (linha < matriz.GetLength(0) - 1)
        Console.WriteLine($"Abaixo: {matriz[linha + 1, coluna]}");
    else
        Console.WriteLine("Abaixo: Não existe.");

    // Esquerda
    if (coluna > 0)
        Console.WriteLine($"Esquerda: {matriz[linha, coluna - 1]}");
    else
        Console.WriteLine("Esquerda: Não existe.");

    // Direita
    if (coluna < matriz.GetLength(1) - 1)
        Console.WriteLine($"Direita: {matriz[linha, coluna + 1]}");
    else
        Console.WriteLine("Direita: Não existe.");
}

// Chamar a função com o número escolhido
MostrarVizinhos(X);