Console.Clear();
Console.WriteLine("Digite o primeiro número inteiro:");
int n1 = LerNumero();
Console.WriteLine("Digite o segundo número inteiro:");
int n2 = LerNumero();

int soma = n1 + n2;
System.Console.WriteLine($"SOMA: {soma}");

static int LerNumero()
{

    while (true)
    {
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            return numero;
        }
        else
        {
            System.Console.WriteLine("Valor inválido. Por favor digite um número inteiro: ");
        }
    }
}
