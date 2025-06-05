namespace Ex17AgainParaTreinar
{
    public class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public List<HourContract> Contracts = new List<HourContract>();
        public Department Department { get; set; }
        public Worker()
        {

        }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income(int month, int year)
        {
            double income = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Month == month && contract.Date.Year == year)
                {
                    income += contract.TotalValue();
                }
            }
            return income;
        }

        public override string ToString()
        {
            // string departmentInfo = "Department: ";
            // if (Department != null)
            // {
            //     departmentInfo += Department.Name;
            // }
            // else
            // {
            //     departmentInfo += "N/A"; 
            // }

            return "Name: " + Name + "\n" +
                   "Level: " + Level.ToString() + "\n" +
                   "Base Salary: " + BaseSalary.ToString("C") + "\n" +
                   "Department: " + Department.Name;
        }
    }
}
