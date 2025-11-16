class Program
{
    static void Main(string[] args)
    {
        int d1 = int.Parse(Console.ReadLine()!);
        int d2 = int.Parse(Console.ReadLine()!);
        Console.Write((2 * (d1 + 3.141592 * d2)).ToString("F6"));
    }
}