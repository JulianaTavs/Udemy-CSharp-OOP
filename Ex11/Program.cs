using Ex11;

// Criando uma instância da classe ContaBancaria
ContaBancaria conta = new ContaBancaria(0, "", 0);

// Solicita o número da conta usando o setter da propriedade
conta.NumeroDaConta = 0;  // Isso chama o setter

// Solicita o nome do titular da conta usando o setter da propriedade
conta.TitularDaConta = "";  // Isso chama o setter

conta.DepositoInicial = ' '; // Isso chama o setter


// Agora você pode obter o número da conta e o nome do titular
int numeroConta = conta.NumeroDaConta;

string titular = conta.TitularDaConta;

char depositoInicial = conta.DepositoInicial;
if (depositoInicial == 's')
{
    conta.ValorDeposito = 0;
    decimal valorDeposito = conta.ValorDeposito;

}

Console.WriteLine(conta);
conta.ValorDeposito = 0;
Console.WriteLine(conta);
conta.ValorSaque = 0;
Console.WriteLine(conta);