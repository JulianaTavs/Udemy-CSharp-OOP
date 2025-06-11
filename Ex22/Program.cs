using Ex22;

List<Product> products = new List<Product>();
GettingValidData gettingValidData = new GettingValidData();

Console.Write("Enter the number of products: ");
int numProd = gettingValidData.NumberOfProducts();

for (int i = 1; i <= numProd; i++)
{
    Console.WriteLine($"Product #{i} data: ");

    Console.Write("Common, used or imported(c/u/i): ");
    TypeOfProduct typeProd = gettingValidData.TypeOfProduct();

    Console.Write("Name: ");
    string prodName = Console.ReadLine();

    
    double prodPrice = gettingValidData.ProductPriceAndProductFee("Price: ",
    "Invalid product price. Please enter a price greater than zero(eg: 141.30): ");

    if (typeProd == TypeOfProduct.Used)
    {
        Console.Write("Manufacture date(dd/MM/yyyy): ");
        DateTime manufactureDate = gettingValidData.ManufactureDate();

        products.Add(new UsedProduct(prodName, prodPrice, manufactureDate));
    }

    else if (typeProd == TypeOfProduct.Imported)
    {
        double customsFee = gettingValidData.ProductPriceAndProductFee("Customs Fee: ",
        "Invalid customs fee. Please enter a value greater than zero(eg: 20.50): ");

        products.Add(new ImportedProduct(prodName, prodPrice, customsFee));
    }
    else
    {
        products.Add(new Product(prodName, prodPrice));
    }
}

Console.WriteLine("---------------------------------------");
foreach (Product product in products)
{
    Console.WriteLine(product.PriceTag());
}

