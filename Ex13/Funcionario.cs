namespace Ex13
{
    class Funcionario
    {
        public int Id { get; private set; }
        public decimal Salario { get; private set; }
        public string Nome { get; set; }
        public Funcionario(int id, decimal salario, string nome)
        {
            Id = id;
            Salario = salario;
            Nome = nome;
        }
        public static void IncreaseSalary(Funcionario funcionario, double percentage)
        {
            decimal aumento = funcionario.Salario * (decimal)(percentage / 100);
            funcionario.Salario += aumento;
        }
        public override string ToString()
        {
            return
                   $"ID: {Id}\n"
                 + $"Nome: {Nome}\n"
                 + $"Salário: {Salario}";
        }
    }
}