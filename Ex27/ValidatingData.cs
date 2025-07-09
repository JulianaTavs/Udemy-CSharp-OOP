using System.Globalization;

namespace Ex27
{
    class ValidatingData
    {
        public string GetAValidString(string prompt, string errorMessage)
        {
            string nameProduct;

            Console.Write(prompt);

            while (true)
            {
                nameProduct = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(nameProduct))
                {
                    return nameProduct;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        public decimal GetAValidDecimal(string prompt, string errorMessage)
        {
            Console.Write(prompt);

            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture,
                 out decimal output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
        public int GetAValidInt(string prompt, string errorMessage)
        {
            Console.Write(prompt);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }

        public string GetAValidCsvFilePath(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string filePath = Console.ReadLine();

                //Verifica se o arquivo existe e se ele tem a extensão .csv:
                if (File.Exists(filePath) && Path.GetExtension(filePath).Equals(".csv",
                StringComparison.OrdinalIgnoreCase))
                {
                    return filePath;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }
            }
        }
    }
}