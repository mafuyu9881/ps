class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000'000'000]
        Console.Write("UOS"[(n - 1) % 3]);
    }
}