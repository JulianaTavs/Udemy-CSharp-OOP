Console.Clear();
Console.WriteLine("Digite o primeiro número inteiro: ");
int A = LerInteiro();
Console.WriteLine("Digite o segundo número inteiro: ");
int B = LerInteiro();
Console.WriteLine("Digite o terceiro número inteiro: ");
int C = LerInteiro();
Console.WriteLine("Digite o quarto número inteiro: ");
int D = LerInteiro();

int DIFERENCA = A * B - C * D;

System.Console.WriteLine($"DIFERENÇA = {DIFERENCA}");

static int LerInteiro()
{
    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            return numero;
        }
        else
        {
            System.Console.WriteLine("Valor inválido. Por favor, digite um número inteiro: ");
        }
    }
}
