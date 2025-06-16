namespace Ex24
{
    class PessoaFisica : TaxPayers
    {
        public decimal HealthExpenses { get; set; }

        public PessoaFisica(string name, decimal annualIncome, decimal healthExpenses)
        : base(name, annualIncome)
        {
            HealthExpenses = healthExpenses;
        }
        public override decimal TaxToPay()
        {
            decimal discount = 0;

            if (HealthExpenses > 0)
            {
                discount = HealthExpenses - (HealthExpenses * 0.5m);
            }

            if (AnnualIncome < 20000)
            {
                return (AnnualIncome * 0.15m) - discount;
            }
            else
            {
                return (AnnualIncome * 0.25m) - discount;
            }
        }
    }
}