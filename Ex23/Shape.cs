namespace Ex23
{
    abstract class Shape
    {
        public Color Color { get; set; }

        public Shape() { }
        public Shape(Color color)
        {
            Color = color;
        }
        public abstract double Area();
    }
}