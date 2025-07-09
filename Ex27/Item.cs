using System.Globalization;

namespace Ex27
{
    class Item
    {
        public string Name { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }

        public Item(string name, decimal itemPrice, int quantity)
        {
            Name = name;
            ItemPrice = itemPrice;
            Quantity = quantity;
        }

        public decimal Total()
        {
            return ItemPrice * Quantity;
        }
        // NOVO MÉTODO: Para formatar a linha para o CSV de saída(summary.csv):
        public string ToSummaryCsvString()
        {
            return $"{Name},{Total().ToString(CultureInfo.InvariantCulture)}";
        }
    }
}