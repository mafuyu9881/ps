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
        while (hi - lo > 1e-6) // max tc = log2(3'000'000'000) = 31.xxx
        {
            double mid = (lo + hi) / 2;

            double c1 = Math.Sqrt(x * x - mid * mid);
            double c2 = Math.Sqrt(y * y - mid * mid);

            double computedC = c1 * c2 / (c1 + c2);
            if (Math.Abs(computedC - c) < 1e-6)
            {
                Console.Write(mid.ToString("F3"));
                break;
            }
            else if (computedC > c)
            {
                lo = mid;
            }
            else // if (computedC < c)
            {
                hi = mid;
            }
        }
    }
}