using System.Globalization;
using System.Text.RegularExpressions;

namespace Ex19
{
    class ValidatingData
    {
        public string GetValidName()
        {
            while (true)
            {
                string nome = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(nome) && Regex.IsMatch(nome, @"^[\p{L}\s'-]+$"))
                // O Regex acima permitirá letras, espaços, apóstrofos e hífens, o que pode 
                // ser mais adequado para nomes.
                {
                    return nome;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente o nome: ");
                }
            }
        }

        public string GetValidEmail()
        {
            while (true)
            {
                string email = Console.ReadLine().Trim().ToLower();

                if (!string.IsNullOrWhiteSpace(email) &&
                Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    return email;
                }
                else
                {
                    Console.WriteLine("Formato de e-mail inválido." +
                    " Certifique -se de que contenha '@' e '.' no domínio.");
                }
            }
        }

        public DateTime GetValidBirthDate()
        {
            DateTime birthDate;

            // Loop para continuar pedindo até que uma data válida seja digitada
            while (true)
            {
                string? input = Console.ReadLine(); // '?' para indicar que pode ser null

                // 1. Tenta converter a string para DateTime
                // Usamos CultureInfo("pt-BR") para garantir que o formato DD/MM/AAAA seja interpretado corretamente
                if (DateTime.TryParse(input, new CultureInfo("pt-BR"), DateTimeStyles.None, out birthDate))
                {
                    // 2. Validações Lógicas (após a conversão bem-sucedida)

                    // Validação 2.1: Não pode ser uma data futura
                    if (birthDate > DateTime.Now)
                    {
                        Console.WriteLine("A data de nascimento não pode ser no futuro. Por favor, tente novamente.");
                    }
                    // Validação 2.2: Opcional - Data não muito no passado (ex: menos de 120 anos)
                    else if (birthDate < DateTime.Now.AddYears(-120))
                    {
                        Console.WriteLine("Data de nascimento muito antiga. Por favor, verifique e tente novamente.");
                    }
                    // Validação 2.3: Opcional - Idade mínima (ex: maior de 18 anos)
                    // Você pode calcular a idade e verificar aqui se necessário
                    /*
                    else if ((DateTime.Now.Year - birthDate.Year) < 18 ||
                             (DateTime.Now.Year - birthDate.Year == 18 && DateTime.Now.DayOfYear < birthDate.DayOfYear))
                    {
                        Console.WriteLine("Você deve ter pelo menos 18 anos. Por favor, tente novamente.");
                    }
                    */
                    else
                    {
                        // Se passou por todas as validações, a data é aceitável
                        break;
                    }
                }
                else
                {
                    // Se TryParse falhou, significa que o formato não é válido
                    Console.WriteLine("Formato de data inválido. Por favor, use DD/MM/AAAA (ex: 25/01/1990).");
                }
            }

            return birthDate;
        }

        public OrderStatus GetValidOrderStatus()
        {
            Console.WriteLine("Enter order data: ");
            Console.WriteLine("0 - PENDING_PAYMENT ");
            Console.WriteLine("1 - PROCESSING ");
            Console.WriteLine("2 - SHIPPED ");
            Console.WriteLine("3 - DELIVERED ");

            while (true)
            {
                Console.Write("Status (0-3): ");
                string? input = Console.ReadLine();

                // Tenta parsear a string diretamente para o enum.
                // True para ignoreCase permite "pending_payment" ou "PENDING_PAYMENT"
                if (Enum.TryParse(input, true, out OrderStatus statusEnum)) // Tenta parsear pelo nome ou pelo valor numérico
                {
                    // O Enum.TryParse já cuida se o valor numérico ou nome existe no enum.
                    // Se o usuário digitar "PENDING_PAYMENT" ou "0", ambos funcionam.
                    return statusEnum;
                }
                else
                {
                    Console.WriteLine("Invalid status. Please enter a number between 0 and 3 or a valid status name (e.g., PENDING_PAYMENT): ");
                }
            }
        }

        public int GetValidNumberOfItems()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the number of items: ");
                }
            }
        }

        public string GetValidProductName()
        {
            while (true)
            {
                string productName = Console.ReadLine().Trim();

                if (!string.IsNullOrWhiteSpace(productName) &&
                Regex.IsMatch(productName, @"^[\p{L}\p{N}\p{P}\p{S}\s]+$") &&
                productName.Length >= 2 && productName.Length <= 255)
                //O Regex verifica se o nome contém apenas letras, números, pontuação, símbolos e espaços.
                //Adição de limite de caracteres acima.
                {
                    return productName;
                }
                else
                {
                    Console.WriteLine("Invalid name. Please enter the product name again: ");
                }
            }
        }

        public double GetValidProductPrice()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), NumberStyles.Currency, new CultureInfo("pt-BR"),
                out double output))
                {
                    if (output > 0) // Preços devem ser positivos, maiores que zero.
                    {
                        return output;
                    }
                    else
                    {
                        Console.WriteLine("Price cannot be negative. Please enter a valid product price: ");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid product price: ");
                }
            }
        }

        public int GetValidProductQuantity()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int output) && output > 0)
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("Invalid input. Value must be greater than zero: ");
                }
            }
        }
    }
}