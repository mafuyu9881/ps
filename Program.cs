class Program
{
    static void Main(string[] args)
    {
        const int Max = 4000000;
        const int MaxSqrt = 2000;

        int n = int.Parse(Console.ReadLine()!);

        List<int> primes = new(Max);
        {
            bool[] prime = new bool[Max + 1];
            for (int i = 0; i < Max + 1; ++i)
            {
                prime[i] = true;
            }

            for (int i = 2; i < MaxSqrt + 1; ++i)
            {
                if (prime[i] == false)
                    continue;

                for (int j = i * i; j < Max + 1; j += i)
                {
                    prime[j] = false;
                }
            }

            for (int i = 2; i < Max + 1; ++i)
            {
                if (prime[i] == false)
                    continue;

                primes.Add(i);
            }
        }

        int cases = 0;
        {
            int sum = 0;
            int lo = 0;
            for (int hi = 0; hi < primes.Count; ++hi)
            {
                sum += primes[hi];

                while (lo < hi && sum > n)
                {
                    sum -= primes[lo];
                    ++lo;
                }

                if (sum == n)
                {
                    ++cases;
                }
            }
        }
        Console.Write(cases);
    }
}