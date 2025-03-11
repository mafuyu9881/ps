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

        long b = nss[0].n; // common denominator
        for (int i = 1; i < nss.Length; ++i)
        {
            b = LCM(b, nss[i].n);
        }

        long a = 0;
        for (int i = 0; i < nss.Length; ++i)
        {
            a += nss[i].s * b / nss[i].n;
        }

        const long X = 1_000_000_007;

        Console.Write(((a % X) * EBS(b, X - 2, X)) % X);
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

    private static long LCM(long a, long b)
    {
        return a * b / GCD(a, b);
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