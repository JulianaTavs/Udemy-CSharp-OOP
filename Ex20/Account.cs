namespace Ex20
{
    public class Account
    {
        public int Number { get; protected set; }
        public string Holder { get; protected set; }
        public double Balance { get; protected set; }

        public Account(){}
        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }
        public virtual void Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount + 5.0;
            }
            else
            {
                Console.WriteLine("You don't have this amount available to withdraw.");
                Console.WriteLine($"Your account balance is: {Balance}");
            }
        }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
}
