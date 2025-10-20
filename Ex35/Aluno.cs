
namespace Ex35
{
    public class Aluno
    {
        private static int _proximoID = 1;
        public int ID { get; private set; }
        public string Nome { get; set; }
        public HashSet<Curso> cursos = new HashSet<Curso>();
        string path = @"D:\Udemy CSharp & OOP\Ex35\pathFile.txt";

        public Aluno(string nome)
        {
            Nome = nome;
            ID = _proximoID;
            _proximoID++;
        }

        public void ListaDeAlunos()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    string cursosString = string.Join(",", cursos.Select(c => c.NomeDoCurso));
                    string linha = $"{ID} {Nome} {cursosString}";
                    sw.WriteLine(linha);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }

        public void MatricularEmCurso()
        {
            Console.WriteLine("Qual o curso que você deseja se matricular?");
            string nomeCurso = Console.ReadLine();

            Console.WriteLine("Digite seu ID: ");
            string idDigitado = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string linha = sr.ReadLine();
                        string[] partes = linha.Split(' ');
                        string id = partes[0];

                        if (idDigitado.Equals(id))
                        {

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            cursos.Add(new Curso(nomeCurso));
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Aluno))
            {
                return false;
            }

            Aluno other = obj as Aluno;

            return ID.Equals(other.ID);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}