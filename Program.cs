using System.Text;

internal class Program
{
    const int MaxSqrtN = 1000000;

    private static void Main(string[] args)
    {
        long n = long.Parse(Console.ReadLine()!); // [1, 10^12]

        int satisfieds;
        if (PerfectSquare(n)) // max tc = 19.xxx
        {
            // If sqrt(n) is an integer, it is intuitively clear
            // that setting it as the base or height of a right triangle
            // allows for the creation of infinitely many right triangles
            // in which at least two sides have integer lengths.
            satisfieds = -1;
        }
        else
        {
            satisfieds = 0;

            SortedSet<long> founds = new();

            for (long a = 1; a * a < n; ++a) // max tc = about 10^6
            {
                long sqrA = a * a;
                long sqrB = n - sqrA;

                if (PerfectSquare(sqrB) == false) // max tc = 19.xxx
                    continue;

                if (founds.Contains(sqrA) || founds.Contains(sqrB)) // max tc = 19.xxx * 2
                    continue;

                founds.Add(sqrA);
                founds.Add(sqrB);

                ++satisfieds;
            }

            for (long i = 1; i * i <= n; ++i) // max tc = about 10^6
            {
                if (n % i != 0)
                    continue;

                long j = n / i;
                if (i % 2 != j % 2) // if two integers have opposite parity
                    continue;

                ++satisfieds;
            }
        }
        Console.Write(satisfieds);
    }

    private static bool PerfectSquare(long x)
    {
        bool output = false;

        int lo = 0 - 1;
        int hi = MaxSqrtN + 1;
        while (lo < hi - 1) // max tc = log2(1'000'000) = 19.xxx
        {
            int mid = (lo + hi) / 2;
            
            long sqrMid = mid * (long)mid;

            if (sqrMid > x)
            {
                hi = mid;
            }
            else if (sqrMid < x)
            {
                lo = mid;
            }
            else
            {
                output = true;
                break;
            }
        }

        return output;
    }
}