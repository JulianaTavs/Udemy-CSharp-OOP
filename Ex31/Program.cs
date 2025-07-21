using Ex31;
int min = 1;
int max = 10;

PrintService<int> printService = new PrintService<int>();
ValidatingData validatingData = new ValidatingData();
PrintService<string> printService2 = new PrintService<string>();

// Lista do tipo INTEIRO da classe PrintService:
Console.WriteLine($"Quantos números você gostaria de adicionar à sua lista entre {min} e {max}:");

int totalOfNumbers = validatingData.ValidatingInt(min, max);
Console.WriteLine("Enter the numbers: ");

for (int i = 0; i < totalOfNumbers; i++)
{
    int number = validatingData.ValidatingIntWithoutParameters();
    printService.AddValue(number);
}

printService.Print();
Console.WriteLine("First: " + printService.First());

// Lista do tipo STRING da classe PrintService:
Console.WriteLine($"Quantos nomes você gostaria de adicionar à sua lista entre {min} e {max}:");

int totalOfNames = validatingData.ValidatingInt(min, max);
Console.WriteLine("Enter the names: ");

for (int i = 0; i < totalOfNames; i++)
{
    string name = validatingData.ValidatingString();
    printService2.AddValue(name);
}

printService2.Print();
Console.WriteLine("First: " + printService2.First());