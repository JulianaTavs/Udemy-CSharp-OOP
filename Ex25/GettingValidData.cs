using System.Globalization;

namespace Ex25
{
    class GettingValidData
    {
        public DateTime GetAValidCheckInDate()
        {
            while (true)
            {
                Console.Write("Check-in date(dd/MM/yyyy): ");

                string checkInDate = Console.ReadLine();
                // Try to parse the CheckInDate string using the defined format:
                if (DateTime.TryParseExact(checkInDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime checkInParsedDate))
                {
                    if (checkInParsedDate.Date >= DateTime.Today.Date)
                    {
                        return checkInParsedDate;
                    }
                    else
                    {
                        Console.WriteLine($"Error in reservation: The date " +
                        $"'{checkInParsedDate.ToShortDateString()}' must be in the future. ");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a date in the format " +
                    "'dd/MM/yyyy': ");
                }
            }
        }
        public DateTime GetAValidCheckOutDate(DateTime checkInReferenceDate)
        {
            DateTime checkOutParsedDate;

            while (true)
            {
                Console.Write("Check-out date(dd/MM/yyyy): ");
                string checkOutDate = Console.ReadLine();
                // Try to parse the CheckOutDate string using the defined format:
                if (DateTime.TryParseExact(checkOutDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out checkOutParsedDate))
                {
                    // Se PARSEOU com sucesso, verifica as REGRAS DE NEGÓCIO:
                    if (checkOutParsedDate.Date > checkInReferenceDate.Date)
                    {
                        return checkOutParsedDate; // A entrada é válida (parse e regra de negócio), sai do loop
                    }
                    else
                    {
                        // Regra de negócio falhou
                        Console.WriteLine($"Error in reservation: The check-out date" +
                        $" '{checkOutParsedDate.ToShortDateString()}' must be greater than the " +
                        $"check-in date '{checkInReferenceDate.ToShortDateString()}'");
                        // O loop continua, pedindo nova entrada
                    }
                }
                else
                {
                    // Parse falhou (formato inválido)
                    Console.WriteLine("Invalid date. Please enter a date in the format 'dd/MM/yyyy': ");
                    // O loop continua, pedindo nova entrada
                }

            }
        }
        public int GetAValidInt(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
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
        public char GetAValidChar()
        {
            while (true)
            {

                if (char.TryParse(Console.ReadLine().ToLower(), out char output) &&
                (output == 'y' || output == 'n'))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid data. Please enter only y for yes or n for no: ");
                }
            }
        }
        
    }
}