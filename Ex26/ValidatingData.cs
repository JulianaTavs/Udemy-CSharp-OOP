using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex26
{
    class ValidatingData
    {
        public int GetAValidInt(string Errormessage)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out int output)
                && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(Errormessage);
                }
            }
        }

        public string GetAValidName()
        {
            while (true)
            {
                string holder = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(holder) &&
                Regex.IsMatch(holder, @"^[a-zA-Z\u00C0-\u017F]+([ \-'][a-zA-Z\u00C0-\u017F]+)*$"))
                // Regex Mais Rigorosa (Evitando espaços duplos e no Início/Fim)
                {
                    return holder;
                }
                else
                {
                    Console.WriteLine("Invalid data. Please enter a valid holder name: ");
                }
            }
        }

        public double GetAValidDouble(string Errormessage)
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(Errormessage);
                }
            }
        }
    }
}