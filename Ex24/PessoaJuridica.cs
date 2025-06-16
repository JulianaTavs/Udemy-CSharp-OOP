namespace Ex24
{
    class PessoaJuridica : TaxPayers
    {
        public int NumberOfEmployees { get; set; }
        public PessoaJuridica(string name, decimal annualIncome, int numberOfEmployees)
        : base(name, annualIncome)
        {
            NumberOfEmployees = numberOfEmployees;
        }
        public override decimal TaxToPay()
        {
            if (NumberOfEmployees <= 10)
            {
                return AnnualIncome * 0.16m;
            }
            else
            {
                return AnnualIncome * 0.14m;
            }
        }
    }
}