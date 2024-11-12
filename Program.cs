internal class Program
{
    private static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);

        long a = tokens[0];
        long b = tokens[1];

        double aSqrt = Math.Sqrt(a);
        double bSqrt = Math.Sqrt(b);

        int candidateCommentCount = 0;
        for (long i = 1; (i * i) <= b; ++i)
        {
            if ((i * i) > a)
            {
                ++candidateCommentCount;
            }
        }
        long allCommentCount = b - a;
        long gcd = ComputeGCD(allCommentCount, candidateCommentCount);

        long numerator = candidateCommentCount / gcd;
        long denominator = allCommentCount / gcd;

        string output;
        if (numerator == 0)
        {
            output = "0";
        }
        else
        {
            output = $"{numerator}/{denominator}";
        }
        Console.Write(output);
    }

    private static long ComputeGCD(long a, long b)
    {
        long bigger = Math.Max(a, b);
        long smaller = Math.Min(a, b);
        while (smaller != 0)
        {
            long r = bigger % smaller;
            bigger = smaller;
            smaller = r;
        }
        return bigger;
    }
}