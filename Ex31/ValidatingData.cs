using System.Text.RegularExpressions;

namespace Ex31
{
    class ValidatingData
    {
        public int ValidatingInt(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output >= min && output <= max)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number between " +
                    $"{min} and {max}:");
                }
            }
        }
        public int ValidatingIntWithoutParameters()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }
            }
        }
        public string ValidatingString()
        {
            while (true)
            {
                string name = Console.ReadLine();
                string namePattern = @"^[A-Za-zÀ-ÖØ-öø-ÿ]+(?:[ -][A-Za-zÀ-ÖØ-öø-ÿ]+)*$";

                if (!string.IsNullOrWhiteSpace(name) &&
                Regex.IsMatch(name, namePattern))
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid name(only letters, "
                    + "spaces and hyphens, no numbers or special symbols):: ");
                }
            }
        }
    }
}