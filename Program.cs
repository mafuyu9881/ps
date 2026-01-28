class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int k = tokens[1];

        int kthDivisor = 0;
        {
            int order = 0;
            for (int i = 1; i <= n; ++i)
            {
                if (n % i != 0)
                    continue;

                ++order;

                if (order < k)
                    continue;

                kthDivisor = i;
                break;
            }
        }

        Console.WriteLine(kthDivisor);
    }
}