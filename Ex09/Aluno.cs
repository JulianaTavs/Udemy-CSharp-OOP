using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex09
{
    public class Aluno
    {
        public string Nome;
        public double Nota1;
        public double Nota2;
        public double Nota3;
        public double NotaFinal;
        public const double NotaMinima = 60;
        public string Status;
        public Aluno()
        {
            Nome = ValidarNome();
            Nota1 = ValidarNotaPrimeiroTrimestre();
            Nota2 = ValidarNotaSegundoETerceiroTrimestres();
            Nota3 = ValidarNotaSegundoETerceiroTrimestres();
            NotaFinal = Nota1 + Nota2 + Nota3;
            Status = StatusAluno();
        }

        public string ValidarNome()
        {
            Console.WriteLine("Digite seu nome: ");
            while (true)
            {
                string nome = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, "^[\\p{L}\\s]+$"))
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("Valor inválido. O nome só pode conter letras e espaços " +
                    "em branco: ");
                }
            }
        }

        public double ValidarNotaPrimeiroTrimestre()
        {
            Console.WriteLine("Digite sua nota do 1°, 2° e 3° trimestres: ");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double valor) && valor >= 0 &&
                 valor <= 30)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. A nota tem que ser entre 0 e 30: ");
                }
            }
        }
        public double ValidarNotaSegundoETerceiroTrimestres()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double valor) && valor >= 0 &&
                 valor <= 35)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. A nota tem que ser entre 0 e 35: ");
                }
            }
        }

        public string StatusAluno()
        {
            if (NotaFinal >= NotaMinima)
            {
                return "APROVADO";
            }
            else
            {
                return "REPROVADO\n" + $"FALTARAM {NotaMinima - NotaFinal} PONTOS.";
            }
        }

        public override string ToString()
        {
            Console.WriteLine("------------------------------------------");
            return $"Nome do aluno: {Nome}\n" +
                   $"Nota do primeiro trimestre: {Nota1.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                   $"Nota do segundo trimestre: {Nota2.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                   $"Nota do terceiro trimestre: {Nota3.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                   $"Nota final: {NotaFinal.ToString("F2", CultureInfo.InvariantCulture)}\n" +
                   $"Status do aluno: {Status}\n";
        }
    }
}