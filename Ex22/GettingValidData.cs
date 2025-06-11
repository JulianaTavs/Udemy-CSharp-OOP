using System.Globalization;

namespace Ex22
{
    public class GettingValidData
    {
        public int NumberOfProducts()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number of products " +
                    "greater than zero: ");
                }
            }
        }
        public TypeOfProduct TypeOfProduct()
        {
            TypeOfProduct output;

            while (true)
            {
                string type = Console.ReadLine().Trim().ToLower();

                // Validação para string vazia
                if (string.IsNullOrEmpty(type))
                {
                    Console.WriteLine("Input cannot be empty. Please enter 'c', 'u', or 'i'.");
                    continue; // Volta para o início do loop
                }

                char typeProd = type[0];

                switch (typeProd)
                {
                    case 'c':
                        output = Ex22.TypeOfProduct.Common;
                        return output;
                    case 'u':
                        output = Ex22.TypeOfProduct.Used;
                        return output;
                    case 'i':
                        output = Ex22.TypeOfProduct.Imported;
                        return output;
                    default:
                        Console.WriteLine("Invalid product type. Please enter 'c', 'u', or 'i'.");
                        break;
                }
            }
        }
        public double ProductPriceAndProductFee(string message, string message2)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double output)
                && output > 0.0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(message2);
                }
            }
        }
        public DateTime ManufactureDate()
        {
            DateTime date;

            while (true)
            {
                string dateString = Console.ReadLine().Trim();

                if (DateTime.TryParseExact(dateString, "dd/MM/yyyy",
                 CultureInfo.InvariantCulture, DateTimeStyles.None, // ou DateTimeStyles.AssumeLocal, etc.
                 out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid data. Please enter the date in the following " +
                    "format dd/MM/yyyy :");
                }
            }
        }
    }
}