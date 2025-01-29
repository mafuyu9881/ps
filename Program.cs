internal class Program
{
    private static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        Console.Write(Math.Abs(tokens[0] - tokens[1]));
    }
}