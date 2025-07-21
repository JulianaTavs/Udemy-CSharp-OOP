namespace Ex31
{
    class PrintService<T>
    {
        private List<T> values = new List<T>();
        public void AddValue(T value)
        {
            values.Add(value);
        }

        public T First()
        {
            if (values.Count == 0)
            {
                throw new InvalidOperationException("A lista está vazia.");
            }
            return values[0];
        }
        public void Print()
        {
            Console.WriteLine($"[{string.Join(", ", values)}]");

            // int j = 0;

            // Console.Write("[");
            // foreach (T i in values)
            // {
            //     if (j < values.Count - 1)
            //     {
            //         Console.Write($"{i}, ");
            //         j++;
            //     }
            //     else
            //         Console.Write(i);
            // }
            // Console.WriteLine("]");
        }
    }
}