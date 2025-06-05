using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex11OutraVersao
{
    class ContaBancaria
    {
        public int Numero { get; private set; }
        public string Titular { get; set; }
        public decimal Saldo { get; private set; }

        public ContaBancaria()
        {
            Numero = LerNumero();
            Titular = LerTitular();
            Saldo = 0;
        }
        public int LerNumero()
        {
            Console.WriteLine("Qual o número da conta:");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Favor inválido! Favor digitar novamente o número da conta:");
                }
            }
        }
        public string LerTitular()
        {
            Console.WriteLine("Qual o nome do titular: ");
            string nome;
            while (true)
            {
                nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, "^[\\p{L}\\s]+$"))
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("Valor inválido. favor digitar novamente o nome: ");
                }
            }
        }
        public void Deposito(decimal quantia)
        {
            Saldo += quantia;
        }
        public void Saque(decimal quantia)
        {
            Saldo -= quantia + 5;
        }
        public char DepositoInicial()
        {
            string letra;
            while (true)
            {
                letra = Console.ReadLine().ToLower();
                if (char.TryParse(letra, out char saida) && (saida == 's' || saida == 'n'))
                {
                    return saida;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar s para SIM ou n para NÃO:");
                }
            }
        }
        // Método para ler um valor decimal com validação
        public decimal LerDecimal(string mensagem)
        {
            decimal valor;
            Console.WriteLine(mensagem);
            while (!decimal.TryParse(Console.ReadLine(), out valor) || valor <= 0)
            {
                Console.WriteLine("Valor inválido. Por favor, digite novamente.");
            }
            return valor;
        }
        public override string ToString()
        {
            return "Dados bancários:\n"
                 + "Número da conta: "
                 + Numero + ", "
                 + "Nome do titular: "
                 + Titular + ", "
                 + "Saldo: "
                 + Saldo.ToString("C");
        }

    }
}