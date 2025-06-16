namespace Ex24
{
    abstract class TaxPayers
    {
        public string Name { get; set; }
        public decimal AnnualIncome { get; set; }
        public TaxPayers(string name, decimal annualIncome)
        {
            Name = name;
            AnnualIncome = annualIncome;
        }
        public abstract decimal TaxToPay();
    }
}
