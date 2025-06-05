namespace Ex17
{
    public class Department
    {
        private ValidatingData validating = new ValidatingData();
        public string Name { get; private set; }

        public Department()
        {
            Console.WriteLine("Enter department's name: ");
            Name = validating.GetAValidName();
        }

        // public override string ToString()
        // {
        //     return Name;
        // }


    }
}