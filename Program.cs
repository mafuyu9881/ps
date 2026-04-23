public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int x0 = tokens[0];
        int n = tokens[1];

        int xn = x0;
        for (int t = 0; t < n; ++t)
        {
            if (xn % 2 == 0)
            {
                xn /= 2;
            }
            else
            {
                xn *= 2;
            }
            xn ^= 6;
        }

        Console.Write(xn);
    }
}