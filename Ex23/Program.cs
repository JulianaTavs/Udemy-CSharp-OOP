using System.Globalization;
using Ex23;

GettingValidated gettingValidated = new GettingValidated();
List<Shape> shapes = new List<Shape>();

Console.Write("Enter the number of shapes: ");
int numberOfShapes = gettingValidated.GetAValidInteger();

for (int i = 1; i <= numberOfShapes; i++)
{
    Console.WriteLine($"Shape #{i} data: ");
    WhichShapeEnum whichShapeEnum = gettingValidated.GetAValidWhichTypeEnum();
    Color color = gettingValidated.GetAValidColor();

    if (whichShapeEnum == WhichShapeEnum.Rectangle)
    {
        double width = gettingValidated.GetAValidDouble("Width: ");
        double height = gettingValidated.GetAValidDouble("Height: ");
        shapes.Add(new Rectangle(color, width, height));
    }
    else if (whichShapeEnum == WhichShapeEnum.Circle)
    {
        double radius = gettingValidated.GetAValidDouble("Radius: ");
        shapes.Add(new Circle(color, radius));
    }
}

Console.WriteLine("--------------------------------------");
Console.WriteLine("SHAPE AREAS: ");

foreach (Shape shape in shapes)
{
    Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
}


