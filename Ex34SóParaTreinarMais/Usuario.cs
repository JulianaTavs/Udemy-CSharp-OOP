namespace Ex34SóParaTreinarMais
{
    public class Usuario
    {
        public string UserName { get; set; }
        public DateTime InstantOfAccess { get; set; }

        public static HashSet<Usuario> usuarios = new HashSet<Usuario>();
        private static readonly string path = @"D:\Udemy CSharp & OOP\Ex34SóParaTreinarMais\log_usuarios.txt";

        public override bool Equals(object? obj)
        {
            if (!(obj is Usuario))
            {
                return false;
            }
            if (obj == null)
            {
                return false;
            }

            Usuario other = obj as Usuario;

            return UserName.Equals(other.UserName, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            return UserName.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }

        public static void GerenciadorDeLog(string nome)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    DateTime instante = DateTime.Now;

                    // As próximas duas linhas de código irão formatar um objeto DateTime em uma 
                    // string específica e depois escrever essa string em um arquivo:

                    string linhaLog = $"{nome} {instante:yyyy-MM-ddTHH:mm:ss}";
                    // Na expressão {instante:yyyy-MM-ddTHH:mm:ss}, você está pegando o objeto DateTime que está 
                    // na variável instante e o está transformando em uma string com um formato específico.
                    // O :yyyy-MM-ddTHH:mm:ss é um formatador de string que diz ao C# como você quer que aquele 
                    // DateTime seja convertido para texto. É uma forma de chamar o método ToString() do DateTime 
                    // com um formato personalizado, mas diretamente dentro da string interpolada.
                    // Então, um objeto DateTime (que é um tipo de dado de tempo) se transforma em uma sequência de 
                    // caracteres (uma string) que representa aquela data e hora no formato que você especificou.

                    sw.WriteLine(linhaLog);
                   
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
        public static void GravadorDeLogsDistintos()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] partes = linha.Split(' ');
                        string nome = partes[0];
                        DateTime instante = DateTime.Parse(partes[1]);
                        usuarios.Add(new Usuario { UserName = nome, InstantOfAccess = instante });
                    }
                }
                Console.WriteLine($"Total users: {usuarios.Count}");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"Arquivo não encontrado: {e.Message}");
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Acesso não autorizado: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro inesperado: {e.Message}");
            }
        }
        public override string ToString()
        {
            return $"{UserName} {InstantOfAccess:yyyy-MM-ddTHH:mm:ss}";
        }
    }
}