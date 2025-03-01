internal class Program
{
    private static void Main(string[] args)
    {
        // element = (0, 3'000'000'000]
        double[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), double.Parse);
        double x = tokens[0];
        double y = tokens[1];
        double c = tokens[2];

        double lo = 0.0;
        double hi = Math.Min(x, y);

        while (Math.Abs(hi - lo) > 1e-6)
        {
            double mid = (lo + hi) / 2;

            double c1 = Math.Sqrt(x * x - mid * mid);
            double c2 = Math.Sqrt(y * y - mid * mid);

            double computedC = c1 * c2 / (c1 + c2);

            if (computedC < c)
            {
                hi = mid;
            }
            else
            {
                lo = mid;
            }
        }

        Console.Write(lo.ToString("F3"));
    }
}