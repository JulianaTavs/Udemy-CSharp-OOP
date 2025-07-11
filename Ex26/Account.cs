using System.Globalization;

namespace Ex26
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new AccountException("Not enough balance.");
            }
            else if (amount > WithdrawLimit)
            {
                throw new AccountException("The amount exceeds withdraw limit.");
            }
            else
            {
                Balance -= amount;
            }
        }
        public override string ToString()
        {
            return "Number: " + Number.ToString() + " | " +
                   "Holder: " + Holder + " | " +
                   "Balance: " + Balance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}