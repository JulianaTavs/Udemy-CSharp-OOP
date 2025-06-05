using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex11
{
    class ContaBancaria
    {
        private int _numeroDaConta;
        private string _titularDaConta;
        private char _depositoInicial;
        private decimal _valorDeposito;
        private decimal _valorSaque;
        public decimal Saldo { get; private set; }
        public ContaBancaria(int numConta, string titular, decimal valorDeposito)
        {
            _numeroDaConta = numConta;
            _titularDaConta = titular;
            _valorDeposito = valorDeposito;
        }
        public int NumeroDaConta
        {
            get { return _numeroDaConta; }
            set
            {
                Console.WriteLine("Digite o número da conta: ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int numero) && numero > 0)
                    {
                        _numeroDaConta = numero;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Digite um número válido para a conta bancária: ");
                    }
                }
            }
        }
        public string TitularDaConta
        {
            get { return _titularDaConta; }
            set
            {
                Console.WriteLine("Digite o nome do titular da conta: ");
                string nome;
                while (true)
                {
                    nome = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, "^[\\p{L}\\s]+$"))
                    {
                        _titularDaConta = nome;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido. O nome só pode conter letras e espaços " +
                        "em branco. Favor tentar novamente: ");
                    }
                }
            }
        }
        public char DepositoInicial
        {
            get { return _depositoInicial; }
            set
            {
                Console.WriteLine("Haverá depósito inicial? s/n: ");
                while (true)
                {
                    string input = Console.ReadLine().ToLower();
                    if (char.TryParse(input, out char valorBool) && (valorBool == 's' ||
                    valorBool == 'n'))
                    {
                        _depositoInicial = valorBool;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Por favor, digite 's' para sim ou 'n' para não.");
                    }
                }
            }
        }
        public decimal ValorDeposito
        {

            get { return _valorDeposito; }
            set
            {
                Console.WriteLine("Quanto você irá depositar?");
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                    {
                        _valorDeposito = valor;
                        Saldo += _valorDeposito;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido. favor digitar o valor do depósito" +
                        " novamente: ");
                    }
                }
            }
        }
        public decimal ValorSaque
        {
            get { return _valorSaque; }
            set
            {
                Console.WriteLine("Quanto deseja sacar?");
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out decimal valor))
                    {
                        _valorSaque = valor;
                        Saldo -= _valorSaque + 5;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido. favor digitar o valor do saque" +
                        " novamente: ");
                    }
                }
            }
        }
        public override string ToString()
        {
            return "Dados da conta:\n"
                + "Conta: " + _numeroDaConta
                + ", "
                + "Titular: " + _titularDaConta
                + ", "
                + "Saldo: $" + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
