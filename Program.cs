class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];
        int k = tokens[2];

        int oCardCount = m;
        int xCardCount = n - m;

        int oCount = k;
        int xCount = n - k;

        int output = 0;
        output += Math.Min(oCardCount, oCount);
        output += Math.Min(xCardCount, xCount);
        Console.Write(output);
    }
}