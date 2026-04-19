public class Program
{
    public static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        long n = tokens[0];
        long m = tokens[1];

        Console.Write((n * m) / 2);
    }
}