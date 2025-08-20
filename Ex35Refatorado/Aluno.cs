namespace Ex35Refatorado
{
    public class Aluno
    {
        private static int _proximoID = 1;
        public int ID { get; private set; }
        public string Nome { get; private set; }
        public HashSet<Curso> CursosMatriculados { get; private set; } = new HashSet<Curso>();

        public Aluno(string nome)
        {
            Nome = nome;
            ID = _proximoID++;
        }

        public override bool Equals(object? obj)
        {
            return obj is Aluno aluno &&
                   ID == aluno.ID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID);
        }
    }
}