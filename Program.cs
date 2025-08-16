class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        Console.Write((n / 10 == n % 10) ? 1 : 0);
    }
}