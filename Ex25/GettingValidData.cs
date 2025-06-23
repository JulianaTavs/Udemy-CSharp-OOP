using System.Globalization;

namespace Ex25
{
    class GettingValidData
    {
        DateTime CheckInParsedDate;
        public DateTime GetAValidCheckInDate()
        {
            while (true)
            {
                Console.Write("Check-in date(dd/MM/yyyy): ");

                string CheckInDate = Console.ReadLine();
                // Try to parse the inputDate string using the defined format:
                if (DateTime.TryParseExact(CheckInDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out CheckInParsedDate))
                {
                    if (CheckInParsedDate.Date >= DateTime.Today.Date)
                    {
                        // Console.WriteLine("Check-in date parsed and accepted successfully: " +
                        // $"{CheckInParsedDate.ToShortDateString()}");
                        return CheckInParsedDate;
                    }
                    else
                    {
                        Console.WriteLine($"Error in reservation: The date " +
                        "'{CheckInParsedDate.ToShortDateString()}' must be in the future. ");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid date. Please enter a date in the format 'dd/MM/yyyy': ");
                }
            }
        }
        public DateTime GetAValidCheckOutDate()
        {
            DateTime CheckOutParsedDate;

            while (true)
            {
                Console.Write("Check-out date(dd/MM/yyyy): ");
                string CheckOutDate = Console.ReadLine();
                // Try to parse the CheckOutDate string using the defined format:
                if (DateTime.TryParseExact(CheckOutDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out CheckOutParsedDate))
                {
                    // Se PARSEOU com sucesso, verifica as REGRAS DE NEGÓCIO:
                    if (CheckOutParsedDate.Date > CheckInParsedDate.Date)
                    {
                        // Console.WriteLine("Check-out date parsed and accepted successfully: " +
                        // $"{CheckOutParsedDate.ToShortDateString()}");
                        return CheckOutParsedDate; // A entrada é válida (parse e regra de negócio), sai do loop
                    }
                    else
                    {
                        // Regra de negócio falhou
                        Console.WriteLine($"Error in reservation: The check-out date" +
                        $" '{CheckOutParsedDate.ToShortDateString()}' must be greater than the " +
                        $"check -in date '{CheckInParsedDate.ToShortDateString()}'");
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
        public int GetAValidInt(string message, string message2)
        {
            Console.Write(message);

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine(message2);
                }
            }
        }
        public int GetAValidNumberOfTheReservation()
        {
            while (true)
            {
                Console.WriteLine("Enter y for yes or n for no: ");

                string input = Console.ReadLine();

                if (char.TryParse(input, out char output) && (output == 'y' || output == 'n'))
                {
                    switch (output)
                    {
                        case 'y':

                            int reservation = GetAValidInt("Which reservation would you like to update? ",
                            "Invalid input. Please enter a valid integer for the number of the " +
                            "reservation: ");

                            return reservation;

                        case 'n':
                            Console.WriteLine("Okay. We are closing the application.");
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid data. Please enter only y for yes or n for no: ");
                }
            }
        }
    }
}