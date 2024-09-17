internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] tokens = Console.ReadLine()!.Split();
        
        int prime_count = 0;

        for (int i = 0; i < n; ++i)
        {
            if (IsPrime(int.Parse(tokens[i])))
            {
                ++prime_count;
            }
        }

        Console.Write(prime_count);
    }

    private static bool IsPrime(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); ++i)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}