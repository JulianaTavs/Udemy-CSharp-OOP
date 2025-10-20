using System.Globalization;

namespace Ex39.Entities
{
    public class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public Product(string name, int id, double price, Category category)
        {
            Name = name;
            Id = id;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return Name + "," +
                   Id.ToString() + "," +
                   Price.ToString("F2", CultureInfo.InvariantCulture) + "," +
                   Category.Name + "," +
                   Category.Tier.ToString();

        }
    }
}