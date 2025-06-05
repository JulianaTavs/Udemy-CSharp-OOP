using Ex19;

ValidatingData validatingData = new ValidatingData();

Console.WriteLine("Enter client data: ");
Console.Write("Name: ");
string name = validatingData.GetValidName();

Console.Write("Email: ");
string email = validatingData.GetValidEmail();

Console.Write("Birth date: ");
Console.WriteLine("Expected format: DD/MM/AAAA (ex: 25/01/1990)");
DateTime birthDate = validatingData.GetValidBirthDate();

Client client = new Client(name, email, birthDate);

OrderStatus orderStatus = validatingData.GetValidOrderStatus();

Order order = new Order(DateTime.Now, orderStatus, client);

Console.WriteLine("How many items to this order? ");
int items = validatingData.GetValidNumberOfItems();


for (int i = 0; i < items; i++)
{
    Console.WriteLine($"Enter #{i + 1} item data: ");
    Console.Write("Product name: ");
    string productName = validatingData.GetValidProductName();
    Console.Write("Product price: ");
    double productPrice = validatingData.GetValidProductPrice();
    Console.Write("Quantity: ");
    int productQuantity = validatingData.GetValidProductQuantity();

    Product product = new Product(productName, productPrice);
    OrderItem orderItem = new OrderItem(productQuantity, productPrice, product);

    order.AddItem(orderItem);
}

Console.WriteLine(order);


