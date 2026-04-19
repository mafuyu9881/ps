public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int s = tokens[0];
        int t = tokens[1];
        int d = tokens[2];

        Console.Write(t * (d / (s * 2)));
    }
}