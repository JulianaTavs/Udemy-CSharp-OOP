namespace Ex35Refatorado
{
    public class Curso
    {
        public string NomeDoCurso { get; private set; }
        public HashSet<Aluno> AlunosMatriculados { get; private set; } = new HashSet<Aluno>();

        public Curso(string nomeDoCurso)
        {
            NomeDoCurso = nomeDoCurso;
        }
        public override string ToString()
        {
            return NomeDoCurso;
        }

        public override bool Equals(object? obj)
        {
            return obj is Curso curso &&
                   NomeDoCurso.Equals(curso.NomeDoCurso, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NomeDoCurso.ToLower());
        }
    }
}