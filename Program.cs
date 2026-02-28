class Program
{
    static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        long a = tokens[0];
        long b = tokens[1];
        long n = tokens[2];

        long digit = 0;
        {
            long r = a % b;

            for (int i = 0; i < n; ++i)
            {
                r *= 10;
                digit = r / b;
                r %= b;
            }
        }

        Console.Write(digit);
    }
}