namespace Ex32
{
    public class CalculationService
    {
        public T Max<T>(List<T> list)
        {
            return list[list.Count - 1];
        }
    }
}