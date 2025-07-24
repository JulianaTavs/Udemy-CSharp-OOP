namespace Ex32ResolvendoComRestricaoDeGenericos
{
    public class CalculationService
    {
        public T Max<T>(List<T> list) where T : IComparable<T>
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("A lista não pode ser nula ou vazia.");
            }
            T max = list[0];

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) > 0) // Se o item atual for "maior" que o máximo 
                // encontrado até agora:
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
}