internal class Program
{
    private static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine()!); // [1, 10'000]

        (int n, int s)[] nss = new (int, int)[m];

        for (int i = 0; i < nss.Length; ++i) // max tc = 10'000
        {
            // length = 2
            // element = [1, 1'000'000'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int n = tokens[0];
            int s = tokens[1];

            nss[i] = (n, s);
        }

        const long X = 1_000_000_007;

        long qSumModX = 0;
        for (int i = 0; i < nss.Length; ++i)
        {
            long a = nss[i].s;
            long b = nss[i].n;

            long gcd = GCD(a, b);
            a /= gcd;
            b /= gcd;

            long bInverseModX = EBS(b, X - 2, X);

            qSumModX = (qSumModX + (((a % X) * bInverseModX) % X)) % X;
        }
        Console.Write(qSumModX);
    }

    private static long GCD(long a, long b)
    {
        long bigger = Math.Max(a, b);
        long smaller = Math.Min(a, b);

        while (smaller > 0)
        {
            bigger %= smaller;

            long temp = bigger;
            bigger = smaller;
            smaller = temp;
        }

        return bigger;
    }

    private static long EBS(long basis, long exponent, long modulus)
    {
        long output = 1;

        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                output = (output * basis) % modulus;
            }

            basis = (basis * basis) % modulus;
            exponent >>= 1;
        }

        return output;
    }
}