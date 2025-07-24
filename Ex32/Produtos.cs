using System.Globalization;

namespace Ex32
{
    public class Produtos : IComparable<Produtos>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produtos(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
        public int CompareTo(Produtos? other)
        {
            if (other == null) return 1;

            return Preco.CompareTo(other.Preco);
        }
        public override string ToString()
        {
            return "Nome: " + Nome + " | " + "Preço: " + Preco.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}