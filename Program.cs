internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Console.Write($"{n * 78 / 100} {(n * 80 / 100) + (n * 20 / 100 * 78 / 100)}");
    }
}