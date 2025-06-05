namespace Ex10
{
    class ConversorDeMoeda
    {
        public static decimal iof = 0.06m;
        public static decimal ValidarCotacaoDoDolar()
        {
            Console.WriteLine("Qual é a cotação do dólar: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("Valor inválido. Favor digitar novamente a cotação do dólar:");
                }
            }
        }
        public static decimal ValidarValor()
        {
            Console.WriteLine("Quantos dólares você vai comprar: ");
            while (true)
            {
                if (decimal.TryParse(Console.ReadLine(), out decimal valor) && valor > 0)
                {
                    return valor;
                }
                else
                {
                    Console.WriteLine("valor inválido. Entre com um valor válido em dólares: ");
                }
            }
        }
        public static decimal PagamentoEmReais()
        {
            decimal valorPagamentoEmReaisSemIOF = ValidarCotacaoDoDolar() * ValidarValor();
            return valorPagamentoEmReaisSemIOF + valorPagamentoEmReaisSemIOF * iof;
        }


    }
}
