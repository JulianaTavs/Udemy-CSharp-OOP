using System.Globalization;

namespace Ex23
{
    class GettingValidated
    {
        public int GetAValidInteger()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer greater than zero: ");
                }
            }
        }
        public WhichShapeEnum GetAValidWhichTypeEnum()
        {
            while (true)
            {
                Console.Write("Rectangle or circle(r/c)? ");
                string type = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(type))
                {
                    Console.WriteLine("Input cannot be empty. Please enter 'r' for rectangle or 'c' for circle.");
                    continue; // Volta para o início do loop
                }

                if (char.TryParse(type, out char output) && (output == 'r' || output == 'c'))
                {
                    switch (output)
                    {
                        case 'r':
                            return WhichShapeEnum.Rectangle;
                        case 'c':
                            return WhichShapeEnum.Circle;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter r for rectangle or c for circle: ");
                }
            }
        }
        public Color GetAValidColor()
        {
            while (true)
            {
                Console.Write("Color(Black/ Blue/ Red): ");
                string color = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrWhiteSpace(color))
                {
                    Console.WriteLine("Input cannot be empty. Please enter Black, Blue or red: ");
                    continue; // Volta para o início do loop
                }

                if (color == "black" || color == "blue" || color == "red")
                {
                    switch (color)
                    {
                        case "black":
                            return Color.BLACK;
                        case "blue":
                            return Color.BLUE;
                        case "red":
                            return Color.RED;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter black, blue or red for the color: ");
                }
            }
        }
        public double GetAValidDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), CultureInfo.InvariantCulture, out double output) && output > 0.0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a decimal number greater " +
                    "than zero: ");
                }
            }
        }
    }
}