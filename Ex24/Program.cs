using System.Globalization;
using Ex24;

GettingDataValidated gettingDataValidated = new GettingDataValidated();
List<TaxPayers> taxPayers = new List<TaxPayers>();

Console.Write("Enter the number of tax payers: ");
int numberTaxPayers = gettingDataValidated.GetAValidInt("Invalid input. Please enter a valid number " +
"of tax payers(Eg: 1, 2, 3, etc): ");

for (int i = 1; i <= numberTaxPayers; i++)
{
    Console.WriteLine($"Tax payer #{i} data: ");

    Console.Write("Individual or company(i/c): ");
    TypeOfTaxPayer typeOfTaxPayer = gettingDataValidated.GetAValidTaxPayer();

    Console.Write("Name: ");
    string name = gettingDataValidated.GetAValidName();

    Console.Write("Annual income: ");
    decimal annualIncome = gettingDataValidated.GetAValidDecimal("Invalid input. " +
    "Please enter a valid decimal annual income: ");

    if (typeOfTaxPayer == TypeOfTaxPayer.Individual)
    {
        Console.Write("Health expenses: ");
        decimal healthExpenses = gettingDataValidated.GetAValidDecimal("Invalid input. " +
        "Please enter a valid decimal health expenses: ");
        taxPayers.Add(new PessoaFisica(name, annualIncome, healthExpenses));
    }
    else
    {
        Console.Write("Number of employees: ");
        int numberOfEmployees = gettingDataValidated.GetAValidInt("Invalid input. Please " +
        "enter a valid number of employees: ");
        taxPayers.Add(new PessoaJuridica(name, annualIncome, numberOfEmployees));
    }
}

Console.WriteLine("-----------------------------------");
Console.WriteLine("TAXES PAID: ");
Console.WriteLine();

decimal sumTaxes = 0;

foreach (TaxPayers payer in taxPayers)
{
    sumTaxes += payer.TaxToPay();
    Console.WriteLine($"{payer.Name}: {payer.TaxToPay().
    ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
}

Console.WriteLine();
Console.WriteLine($"TOTAL TAXES: {sumTaxes.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
Console.WriteLine("-----------------------------------");