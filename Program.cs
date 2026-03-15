public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int t = tokens[1];
        Console.Write(Math.Max(0, 10 + 2 * (25 - a + t)));
    }
}