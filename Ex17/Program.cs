
using Ex17;

ValidatingData validating = new ValidatingData();

Worker worker1 = new Worker();

Console.WriteLine("How many contracts to this worker? ");

int numberOfContracts = validating.GetNumberOfContracts();

for (int i = 0; i < numberOfContracts; i++)
{
    Console.WriteLine($"Contract #{i + 1}: ");
    HourContract contract = new HourContract();
    worker1.AddContract(contract);
}
Console.WriteLine("---------------------------------------------");
Console.WriteLine($"Income: " + worker1.Income().ToString("C2"));
Console.WriteLine(worker1.ToString());
Console.WriteLine("---------------------------------------------");
