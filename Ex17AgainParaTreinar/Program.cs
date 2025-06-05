using Ex17AgainParaTreinar;

Console.WriteLine("Enter department's name: ");
string departmentName = Console.ReadLine()!;
Department dept = new Department(departmentName);

Worker worker = new Worker();

worker.Department = dept;

Console.WriteLine("Enter worker data: ");
Console.Write("Name: ");
worker.Name = Console.ReadLine()!;

Console.Write("Level (0-JUNIOR, 1-MIDLEVEL, 2-SENIOR): ");

while (true)
{
    if (int.TryParse(Console.ReadLine(), out int level))
    {
        if (level == 0 || level == 1 || level == 2)
        {
            switch (level)
            {
                case 0:
                    worker.Level = WorkerLevel.JUNIOR;
                    break;
                case 1:
                    worker.Level = WorkerLevel.MIDLEVEL;
                    break;
                case 2:
                    worker.Level = WorkerLevel.SENIOR;
                    break;
            }
            break;
        }
        else
        {
            Console.Write("Nível inválido. Por favor, digite 0, 1 ou 2: ");
        }
    }
    else
    {
        Console.Write("Entrada inválida. Por favor, digite um número inteiro: ");
    }
}

Console.Write("Base Salary: ");
worker.BaseSalary = double.Parse(Console.ReadLine()!);

Console.Write("How many contracts to this worker? ");
int numContracts = int.Parse(Console.ReadLine()!);

for (int i = 0; i < numContracts; i++)
{
    Console.WriteLine($"Enter {i + 1} contract data:");

    Console.Write("Date (dd/MM/yyyy): ");
    DateTime date = DateTime.Parse(Console.ReadLine()!.Trim());

    Console.Write("Value per hour: ");
    double perHour = double.Parse(Console.ReadLine()!.Trim());

    Console.Write("Duration (hours): ");
    int duration = int.Parse(Console.ReadLine()!);

    worker.Contracts.Add(new HourContract(date, perHour, duration));
}

Console.Write("Enter month and year to calculate income (MM/yyyy): ");
string monthAndYear = Console.ReadLine()!.Trim();
int month = int.Parse(monthAndYear.Substring(0, 2));
int year = int.Parse(monthAndYear.Substring(3));

Console.WriteLine("----------------------------");
Console.WriteLine(worker);
Console.WriteLine("----------------------------");
Console.WriteLine("Income: " + worker.Income(month, year).ToString("C"));
