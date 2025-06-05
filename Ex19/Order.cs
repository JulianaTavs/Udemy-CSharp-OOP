
using System.Globalization;
using System.Text;

namespace Ex19
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; } = new Client();

        public Order() { }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach (var item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Order summary:\n");

            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items: ");

            foreach (var item in Items)
            {
                sb.AppendLine($"{item.Product.Name}, " +
                $"{item.Price.ToString("C")}, " +
                $"Quantity: {item.Quantity}, Subtotal: {item.SubTotal().ToString("C")}");
            }
            sb.AppendLine($"Total price: {Total().ToString("C")}");
            return sb.ToString();
        }
    }
}