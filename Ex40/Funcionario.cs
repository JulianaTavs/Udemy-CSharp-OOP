using System.Globalization;

namespace Ex40
{
    public class Funcionario
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Funcionario(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }
        public override string ToString()
        {
            return Name + "," + Email + "," + Salary.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}