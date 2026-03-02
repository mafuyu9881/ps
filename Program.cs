class Program
{
    static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        long a = tokens[0];
        long b = tokens[1];
        long c = tokens[2];

        long rhs = (a * a - b * b) * (a * a - c * c);

        long output = -1;
        {
            for (long x = 1; x < a; ++x)
            {
                long lhsSqrt = a * x + b * c;
                if (lhsSqrt * lhsSqrt == rhs)
                {
                    output = x;
                    break;
                }
            }
        }

        Console.Write(output);
    }
}