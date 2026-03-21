public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        long[] purses = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

        Console.Write(purses.Sum() % 3 == 0 ? "yes" : "no");
    }
}