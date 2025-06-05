using Ex11OutraVersao;

ContaBancaria conta = new ContaBancaria();

Console.WriteLine("Você deseja fazer um depósito inicial? s/n");
char Inicial = conta.DepositoInicial();
if (Inicial == 's')
{

    decimal valor = conta.LerDecimal("Quanto você deseja depositar?");
    conta.Deposito(valor);
}

Console.WriteLine(conta);

decimal quantia = conta.LerDecimal("Quanto você deseja depositar?");
conta.Deposito(quantia);

Console.WriteLine(conta);

quantia = conta.LerDecimal("Quanto você deseja sacar?");
conta.Saque(quantia);

Console.WriteLine(conta);