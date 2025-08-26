class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine(n * (n + 1) / 2);
        Console.WriteLine(n * (n + 1) / 2 * n * (n + 1) / 2);
        Console.WriteLine(n * (n + 1) / 2 * n * (n + 1) / 2);
    }
}