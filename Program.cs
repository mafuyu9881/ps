internal class Program
{
    private static void Main(string[] args)
    {
        // length = 2
        // element = [1, 100'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];
        Console.Write($"{(a + b) * (long)(a - b)}");
    }
}