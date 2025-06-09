using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex21
{
    public class GettingValidData
    {
        public int GetAValidNumberOfEmployees()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid"
                    + " number of employess greater than zero: ");
                }
            }
        }
        public char GetAValidEmployeeType()
        {
            while (true)
            {
                string type = Console.ReadLine().Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(type))
                {
                    if (type[0] == 'y' || type[0] == 'n')
                        return type[0];
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter y for yes or n for no: ");
                }
            }
        }
        public string GetAValidName()
        {
            while (true)
            {
                string name = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(name) &&
                Regex.IsMatch(name, @"^[a-zA-ZáàâãéèêíïóôõöúüçÁÀÂÃÉÈÊÍÏÓÔÕÖÚÜÇ\s]+$") &&
                name.Length > 2 && name.Length < 200)
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Name must have only letters and spaces (no numbers or special " +
                    "characters).");
                }
            }
        }
        public int GetValidHours()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number greater than 0: ");
                }
            }
        }
        public double GetValidValuePerHour()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalue input. Please enter the number of hours you worked: ");
                }
            }
        }
        public double GetAValidAdditionalCharge()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalue input. Please enter the additional charge for the " +
                    "outsourced employee: ");
                }
            }
        }
    }
}