namespace Ex35Refatorado
{
    public class Instrutor
    {
        public NomesDosInstrutores NomeInstrutor { get; private set; }
        public HashSet<Curso> CursosMinistrados { get; private set; } = new HashSet<Curso>();

        public Instrutor(NomesDosInstrutores nome)
        {
            NomeInstrutor = nome;
        }

        // Método para calcular o total de alunos únicos em todos os seus cursos.
        // Ele usa o método UnionWith para combinar todos os HashSets de alunos
        // e contar o total sem repetições.
        public int TotalDeAlunosDosMeusCursos()
        {
            // Cria um HashSet para armazenar todos os alunos únicos
            var todosAlunos = new HashSet<Aluno>();
            
            // Itera sobre cada curso que o instrutor ministra
            foreach (var curso in CursosMinistrados)
            {
                // Usa UnionWith para adicionar todos os alunos do curso atual
                // ao nosso HashSet de todos os alunos. O HashSet se encarrega de
                // não adicionar alunos repetidos.
                todosAlunos.UnionWith(curso.AlunosMatriculados);
            }

            return todosAlunos.Count;
        }
        
        public override bool Equals(object? obj)
        {
            return obj is Instrutor instrutor && NomeInstrutor == instrutor.NomeInstrutor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NomeInstrutor);
        }
    }
}