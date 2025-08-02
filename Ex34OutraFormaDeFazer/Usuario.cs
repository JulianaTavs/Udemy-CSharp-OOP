namespace Ex34OutraFormaDeFazer
{
    public class Usuario
    {
        public string UserName { get; set; }
        public DateTime AccessInstant { get; set; }

        private static readonly string LogFilePath = @"D:\Udemy CSharp & OOP\Ex34OutraFormaDeFazer\log_usuarios.txt";

        static HashSet<Usuario> distinctUsers = new HashSet<Usuario>();
        public Usuario(string userName, DateTime accessInstant)
        {
            UserName = userName;
            AccessInstant = accessInstant;
        }

        /// <summary>
        /// Registra o nome do usuário e o instante do login em um arquivo de log.
        /// </summary>
        /// <param name="nomeUsuario">O nome do usuário que fez o login.</param>

        public static void RegistrarLogUsuario(string nomeUsuario)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {

                    DateTime agora = DateTime.Now;
                    string instanteFormatado = agora.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    string linhaLog = $"{nomeUsuario} {instanteFormatado}";

                    sw.WriteLine(linhaLog);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro de exceção: {ex.Message}");
            }
        }

        /// <summary>
        /// Lê o arquivo de log e calcula o total de usuários distintos.
        /// Exibe a contagem e a lista de usuários distintos no console.
        /// </summary>
        public static void TotalUsuariosDistintos()
        {
            distinctUsers.Clear(); // Limpa o HashSet antes de cada leitura para recontar
            try
            {
                using (StreamReader sr = new StreamReader(LogFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] partes = linha.Split(' ', 2); // Dividimos a string usando o espaço, mas limitamos a 2 partes.
                                                               // A primeira parte será o nome, e a segunda parte será TODO O RESTO da string.
                        string nome = partes[0];
                        DateTime instante = DateTime.Parse(partes[1]);
                        distinctUsers.Add(new Usuario(nome, instante));
                    }
                    Console.WriteLine($"\nTotal distinct users: {distinctUsers.Count}");

                    Console.WriteLine("--------------------------------");
                    foreach (Usuario usuario in distinctUsers)
                    {
                        Console.WriteLine(usuario);
                    }
                    Console.WriteLine("--------------------------------");
                }
            }
            catch (FileNotFoundException ex) // Captura um tipo especí­fico de erro
            {
                Console.WriteLine($"Erro: Arquivo não encontrado! {ex.Message}");
            }
            catch (UnauthorizedAccessException ex) // Captura outro tipo de erro
            {
                Console.WriteLine($"Erro de permissão: {ex.Message}");
            }
            catch (Exception ex) // Captura qualquer outro erro inesperado
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        /// <summary>
        /// Compara dois objetos Usuario para verificar a igualdade (baseado no UserName).
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Usuario))
            {
                return false;
            }

            Usuario other = obj as Usuario;

            return UserName.Equals(other.UserName, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gera o código hash para o objeto Usuario (baseado no UserName).
        /// </summary>
        public override int GetHashCode()
        {
            return UserName.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Retorna uma representação em string do objeto Usuario.
        /// </summary>
        public override string ToString()
        {
            return $"{UserName} {AccessInstant}";
        }
    }
}