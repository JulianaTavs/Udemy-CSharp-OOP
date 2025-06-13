namespace Ex23
{
    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle() { }
        public Circle(Color color, double radius)
        : base(color)
        {
            Radius = radius;
        }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}