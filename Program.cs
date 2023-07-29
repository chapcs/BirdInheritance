internal class Program
{
    private static void Main(string[] args)
    {
        string[] spinner = { "/", "-", "\\", "|" };

        while (true)
        {
            Bird bird;
            Console.Write("Press P for pigeon, O for ostrich: ");
            char key = Char.ToUpper(Console.ReadKey().KeyChar);
            if (key == 'P') bird = new Pigeon();
            else if (key == 'O') bird = new Ostrich();
            else return;

            Console.Write("\nHow many eggs should it lay? ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
            Egg[] eggs = bird.LayEggs(numberOfEggs);
            int numBrokenEggs = 0;

            foreach (Egg egg in eggs)
            {
                if (egg is BrokenEgg) numBrokenEggs++;
                int count = 0;
                while (count < 15)
                {
                    Console.Write("\rLaying " + spinner[count % spinner.Length]);
                    count++;
                    Thread.Sleep(75);
                }
                Console.WriteLine("\r" + egg.Description);
            }
            Console.WriteLine($"{numBrokenEggs} eggs were broken out of {numberOfEggs}");
            Console.WriteLine();
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
        get 
        {
            if (Size == 0) return $"A {Color} egg";
            return $"A {Size:0.0}cm {Color} egg"; 
        }
    }
}

class BrokenEgg : Egg
{
    public BrokenEgg(string color) : base(0, $"broken {color}") { }
}

abstract class Bird
{
    public static Random Randomizer = new Random();
    public abstract Egg[] LayEggs(int numberOfEggs); // cannot have body or be virtual
}

class Pigeon : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] eggs = new Egg[numberOfEggs];

        for (int i = 0; i < numberOfEggs; i++)
        {
            if (Bird.Randomizer.Next(4) == 0)
                eggs[i] = new BrokenEgg("white"); //modified to only take the color param
            else
                eggs[i] = new Egg(Bird.Randomizer.NextDouble() * 2 + 1, "white");
        }
        return eggs;
    }
}

class Ostrich : Bird
{
    public override Egg[] LayEggs(int numberOfEggs)
    {
        Egg[] eggs = new Egg[numberOfEggs];
        for (int i = 0; i < numberOfEggs; i++)
        {
            if (Bird.Randomizer.Next(3) == 0)
                eggs[i] = new BrokenEgg("speckled");
            else
                eggs[i] = new Egg(Bird.Randomizer.NextDouble() + 12, "speckled");
        }
        return eggs;
    }
}