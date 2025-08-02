using Ex34OutraFormaDeFazer;


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Simulador de Sistema de Log de Usuários ---");

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Registrar Login de Usuário");
            Console.WriteLine("2 - Ver Total de Usuários Distintos e Logs");
            Console.WriteLine("3 - Sair");
            Console.Write("Opção: ");

            string? opcao = Console.ReadLine(); 

            switch (opcao)
            {
                case "1":
                    Console.Write("\nDigite o nome do usuário para registrar o login: ");
                    string? nomeUsuario = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nomeUsuario))
                    {
                        
                        Usuario.RegistrarLogUsuario(nomeUsuario);
                    }
                    else
                    {
                        Console.WriteLine("Nome de usuário inválido. Tente novamente.");
                    }
                    break;

                case "2":

                    Usuario.TotalUsuariosDistintos();
                    break;

                case "3":
                    continuar = false;
                    Console.WriteLine("\nSaindo do simulador. Até mais!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha 1, 2 ou 3.");
                    break;
            }
        }

        Console.ReadKey();
    }
}







