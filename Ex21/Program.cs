using Ex21;

GettingValidData gettingValidData = new GettingValidData();

List<Employee> allEmployees = new List<Employee>();

Console.Write("Enter number of employees? ");
int number = gettingValidData.GetAValidNumberOfEmployees();

for (int i = 0; i < number; i++)
{
    Console.WriteLine($"Employee #{i + 1} data: ");

    Console.Write("Outsourced(y/n)? ");
    char employeeType = gettingValidData.GetAValidEmployeeType();

    Console.Write("Name: ");
    string name = gettingValidData.GetAValidName();

    Console.Write("Hours: ");
    int hours = gettingValidData.GetValidHours();

    Console.Write("Value per hour: ");
    double valuePerHour = gettingValidData.GetValidValuePerHour();

    if (employeeType == 'y')
    {
        Console.Write("Additional charge: ");
        double additional = gettingValidData.GetAValidAdditionalCharge();

        allEmployees.Add(new OutsourcedEmployee(name, hours, valuePerHour, additional));
    }

    if (employeeType == 'n')
    {
        allEmployees.Add(new Employee(name, hours, valuePerHour));
    }
}

Console.WriteLine();
Console.WriteLine("Payments: ");
Console.WriteLine("------------------------------");

foreach (Employee item in allEmployees)
{
    Console.WriteLine($"{item.Name}: $ {item.Payment()}");
}


