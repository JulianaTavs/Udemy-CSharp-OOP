namespace Ex17
{
    class Worker
    {
        public string Name { get; private set; }
        public WorkerLevel Level { get; private set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        private ValidatingData validating = new ValidatingData();
        public Worker()
        {
            Console.WriteLine("Enter worker data: ");

            Name = validating.GetAValidName();

            Level = validating.GetAValidLevel();

            BaseSalary = validating.GetAValidBaseSalary();

            Department = new Department();

        }
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income()
        {
            (int month, int year) = validating.MonthAndYear();

            double sum = BaseSalary;

            foreach (HourContract contract in Contracts)

                if (year == contract.Date.Year && month == contract.Date.Month)
                {
                    sum += contract.TotalValue();
                }

            return sum;
        }
        public override string ToString()
        {
            return "Name: " + Name + "\n"
                   + "Level: " + Level + "\n"
                   + "Department: " + Department.Name;
        }
    }
}