namespace Ex33
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Sobrescrita do método Equals(object obj):
        public override bool Equals(object obj)
        {
            // 1. Verifica se o objeto de comparação é nulo.
            if (obj == null)
            {
                return false;
            }

            // 2. Verifica se o objeto de comparação é do mesmo tipo.
            //    'is Product' verifica se obj é um Product ou uma classe que herda de Product.
            //    GetType() != obj.GetType() seria mais rigoroso, exigindo exatamente o mesmo tipo.
            if (!(obj is Product otherProduct)) // 'otherProduct' será null se 'obj' não for um Product
            {
                return false;
            }

            // 3. Compara os valores das propriedades.
            //    Usando StringComparison.OrdinalIgnoreCase para comparação de nomes sem distinção de 
            //    maiúsculas/minúsculas.
            return Name.Equals(otherProduct.Name, StringComparison.OrdinalIgnoreCase) &&
                   Price.Equals(otherProduct.Price);
        }

        // Sobrescrita do método GetHashCode() - Essencial quando Equals() é sobrescrito:
        public override int GetHashCode()
        {
            // Combina os hash codes das propriedades que são usadas na comparação Equals.
            // O operador '?? 0' lida com o caso em que 'Name' pode ser nulo, evitando NullReferenceException.
            return HashCode.Combine(
                Name?.GetHashCode(StringComparison.OrdinalIgnoreCase) ?? 0,
                Price
            );
        }
    }
}