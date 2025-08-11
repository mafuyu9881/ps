class Program
{
    static void Main(string[] args)
    {
        int r = int.Parse(Console.ReadLine()!);
        int g = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);
        Console.Write(r * 3 + g * 4 + b * 5);
    }
}