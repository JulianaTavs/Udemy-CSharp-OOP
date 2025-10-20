namespace Ex35
{
    public class Curso
    {
        public string NomeDoCurso { get; set; }
        public HashSet<Aluno> alunos = new HashSet<Aluno>();

        public Curso(string nomeDoCurso)
        {
            NomeDoCurso = nomeDoCurso;
        }
        public override string ToString()
        {
            return NomeDoCurso;
        }
    }
}