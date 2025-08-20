namespace Ex36
{
    public class Candidato
    {
        public string Nome { get; set; }
        public int TotalVotos { get; set; } = 0;

        public Candidato(string nome)
        {
            Nome = nome;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Candidato))
            {
                return false;
            }
            Candidato other = obj as Candidato;

            return Nome.Equals(other.Nome);
        }

        public override int GetHashCode()
        {
            return Nome.GetHashCode();
        }
    }
}