using Ex37.Entities;
using System.Collections.Generic;

    List<Product> list = new List<Product>();

    list.Add(new Product("Tv", 900.00));
    list.Add(new Product("Mouse", 50.00));
    list.Add(new Product("Tablet", 350.00));
    list.Add(new Product("HD Case", 80.90));

    // List<Product> list2 = new List<Product>();

    // foreach (Product p in list)
    // {
    //     list2.Add(new Product(p.Name.ToUpper(), p.Price));
    // }

    // foreach (Product product1 in list2)
    // {
    //     Console.WriteLine(product1);
    // }

    Func<Product, string> func = NameUpper; // 1. Delegate explícito

    List<string> result = list.Select(func).ToList(); // 2. Passa o delegate
    foreach (string s in result)
    {
        Console.WriteLine(s);
    }

static string NameUpper(Product p)  // 3. Método separado
{
    return p.Name.ToUpper();
}

// Abordagem Equivalente (Lambda Expression):
// Define a transformação inline (no local):

// List<string> result = list.Select(p => p.Name.ToUpper()).ToList();

// Não precisa do método NameUpper, pois a lógica está na lambda (p => p.Name.ToUpper())



