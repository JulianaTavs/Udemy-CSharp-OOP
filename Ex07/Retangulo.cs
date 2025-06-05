using System.Globalization;

namespace Ex07
{
    public class Retangulo
    {
        public double Altura;
        public double Largura;


        public double Area()
        {
            double area = Altura * Largura;

            return area;
        }

        public double Perimetro()
        {
            double perimetro = 2 * (Altura + Largura);

            return perimetro;
        }

        public double Diagonal()
        {
            double diagonal = Math.Sqrt(Math.Pow(Largura, 2) + Math.Pow(Altura, 2));

            return diagonal;
        }

        public double ValidarValores()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double valor) && valor > 0)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor entre novamente com o valor:");
                }
            }
        }

        public override string ToString()
        {
            return "ÁREA: " + Area().ToString("F2", CultureInfo.InvariantCulture) + "\n" +
                   "PERÍMETRO: " + Perimetro().ToString("F2", CultureInfo.InvariantCulture) + "\n" +
                   "DIAGONAL: " + Diagonal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
