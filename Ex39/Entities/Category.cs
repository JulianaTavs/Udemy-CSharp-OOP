namespace Ex39.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
        public Category(string name, int tier)
        {
            Name = name;
            Tier = tier;
        }
    }
}