internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Bird bird;
        }
    }
}

class Egg
{
    public double Size { get; private set; }
    public string Color { get; private set; }
    public Egg(double size, string color)
    {
        Size = size;
        Color = color;
    }
    public string Description
    {
        get { return $"A {Size:0.0}cm {Color} egg"; }
    }
}

class Bird
{

}

class Pigeon : Bird
{

}

class Ostroch : Bird
{

}