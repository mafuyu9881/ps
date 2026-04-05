public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int w = tokens[0];
        int v = tokens[1];

        Console.Write((w / v) >= a ? 1 : 0);
    }
}