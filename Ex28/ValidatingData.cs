using System.Globalization;

namespace Ex28
{
    class ValidatingData
    {
        public DateTime GetAValidDateTime(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string date = Console.ReadLine().Trim();
                if (DateTime.TryParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, 
                 DateTimeStyles.None, out DateTime output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
        public string GetAValidString(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string model = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(model))
                {
                    return model;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
        public decimal GetAValidDecimal(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any,
                CultureInfo.InvariantCulture, out decimal output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}