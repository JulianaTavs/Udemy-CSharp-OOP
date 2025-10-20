namespace Ex35
{
    public class Instrutor
    {
        public NomesDosInstrutores NomeInstrutor { get; private set; }
        public HashSet<Curso> cursos = new HashSet<Curso>();
        public void AdicionarCurso()
        {
            Console.Write("Qual curso você gostaria de adicionar? ");
            string nomeCurso = Console.ReadLine();
            cursos.Add(new Curso(nomeCurso));
            Console.WriteLine($"Curso '{nomeCurso}' adicionado com sucesso!");
        }

        public void ExcluirCurso()
        {
            Console.WriteLine("Qual curso você gostaria de excluir?");
            string nomeCurso = Console.ReadLine();

            cursos.Remove(new Curso(nomeCurso));
        }
        public void ImprimirCursos()
        {
            foreach (Curso curso in cursos)
                Console.WriteLine(curso);
        }

        public void TotalDeAlunosDosMeusCursos()
        {
            
        }
    }
}