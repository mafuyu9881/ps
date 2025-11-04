class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        int c = int.Parse(Console.ReadLine()!);
        int d = int.Parse(Console.ReadLine()!);
        int e = int.Parse(Console.ReadLine()!);

        int elapsedTime = 0;

        if (a < 0)
        {
            elapsedTime += (0 - a) * c;
            elapsedTime += d;
            a = 0;
        }

        elapsedTime += (b - a) * e;

        Console.Write(elapsedTime);
    }
}