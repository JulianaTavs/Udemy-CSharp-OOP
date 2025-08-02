namespace Ex34
{
    public class LogManager
    {
        private static readonly string LogFilePath = @"D:\Udemy CSharp & OOP\Ex34\log_usuarios.txt"; 
        static HashSet<string> distinctUsers = new HashSet<string>();

        /// <summary>
        /// Registra o nome do usuário e o instante do login em um arquivo de log.
        /// </summary>
        /// <param name="nomeUsuario">O nome do usuário que fez o login.</param>
        public static void RegistrarLogUsuario(string nomeUsuario)
        {
            
            DateTime agora = DateTime.Now;

            string instanteLogin = agora.ToString("yyyy-MM-dd HH:mm:ss");

            string linhaLog = $"{nomeUsuario} {instanteLogin}";

            try
            {
                // Abre o arquivo em modo de adição (append) para não sobrescrever logs anteriores.
                // Se o arquivo não existir, ele será criado.
                // true no segundo parâmetro indica append (adicionar ao final).
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine(linhaLog); 
                }
                Console.WriteLine($"Log registrado com sucesso para: {nomeUsuario}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever no arquivo de log: {ex.Message}");
            }
        }

        public static void TotalDistinctUsers()
        {
            try
            {
                using (StreamReader sr = new StreamReader(LogFilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] partes = linha.Split(' ');

                        if (partes.Length > 0)
                        {
                            string nome = partes[0];
                            distinctUsers.Add(nome);
                        }
                    }
                }
            }
            catch (FileNotFoundException ex) 
            {
                Console.WriteLine($"Erro: Arquivo não encontrado! {ex.Message}");
            }
            catch (UnauthorizedAccessException ex) 
            {
                Console.WriteLine($"Erro de permissão: {ex.Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }

            Console.WriteLine($"Total users: {distinctUsers.Count}");
        }
    }
}