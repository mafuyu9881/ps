class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int a = tokens[0];
        int b = tokens[1];
        int c = tokens[2];
        int d = tokens[3];

        int diff0 = Math.Abs((a + b) - (c + d));
        int diff1 = Math.Abs((a + c) - (b + d));
        int diff2 = Math.Abs((a + d) - (b + c));

        Console.Write(Math.Min(diff0, Math.Min(diff1, diff2)));
    }
}