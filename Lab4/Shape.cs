namespace Lab4;

public class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public Shape(int x, int y, int height, int width)
    {
        X = x;
        Y = y;
        Height = height;
        Width = width;
    }

    public virtual void Draw()
    {
        Console.WriteLine();
    }
}

public class Rectangle : Shape
{
    public Rectangle(int x, int y, int height, int width) : base(x, y, height, width)
    {
    }

    public override void Draw()
    {
        Console.WriteLine("Rectangle");
    }
}

public class Circle : Shape
{
    public Circle(int x, int y, int height, int width) : base(x, y, height, width)
    {
    }

    public override void Draw()
    {
        Console.WriteLine("Circle");
    }
}

public class Triangle : Shape
{
    public Triangle(int x, int y, int height, int width) : base(x, y, height, width)
    {
    }

    public override void Draw()
    {
        Console.WriteLine("Triangle");
    }
}