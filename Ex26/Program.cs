using System.Globalization;
using Ex26;

List<Account> accounts = new List<Account>();
ValidatingData validatingData = new ValidatingData();

Console.Write("How many accounts would you like to register? ");
int numberOfAccounts = validatingData.GetAValidInt("Invalid data. Please enter a whole number for" +
"the number of accounts: ");

for (int i = 1; i <= numberOfAccounts; i++)
{
    Console.WriteLine($"Enter account data {i}: ");

    Console.Write("Number: ");
    int number = validatingData.GetAValidInt("Invalid data. Please enter a whole number for" +
    "the account number: ");

    Console.Write("Holder: ");
    string holder = validatingData.GetAValidName();

    Console.Write("Initial balance: ");
    double initialBalance = validatingData.GetAValidDouble(
    "Invalid data. Please enter a valid account balance: ");

    Console.Write("Withdraw limit: ");
    double withdrawLimit = validatingData.GetAValidDouble(
    "Invalid data. Please enter a valid withdraw limit: ");

    Account account1 = new Account(number, holder, initialBalance, withdrawLimit);
    accounts.Add(account1);
}
int j = 1;
foreach (var item in accounts)
{
    Console.WriteLine($"{j} - " + item);
    j++;
}

int whichAccount;

while (true)
{
    Console.Write("Which account would you like to withdraw money from? ");
    whichAccount = validatingData.GetAValidInt("Invalid data. Please enter a whole number for " +
    "the account number: ");

    if (whichAccount >= 1 && whichAccount <= accounts.Count)
    {
        break; // Número de conta válido, sai do loop
    }
    else
    {
        Console.WriteLine($"Invalid account number. Please choose a number between 1 and {accounts.Count}.");
    }
}

Console.Write("Enter amount for withdraw: ");
double withdrawAmount = validatingData.GetAValidDouble("Invalid data. Please enter a " +
"valid withdraw amount: ");

try
{
    accounts[whichAccount - 1].Withdraw(withdrawAmount);
    Console.Write("New balance: ");
    Console.WriteLine(accounts[whichAccount - 1].Balance.ToString("F2", CultureInfo.InvariantCulture));
}
catch (AccountException ex)
{
    Console.WriteLine($"Withdraw failure: {ex.Message}");
}

