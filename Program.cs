class Program
{
    static void Main(string[] args)
    {
        long[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), long.Parse);
        long a = tokens[0];
        long b = tokens[1];

        long s = Math.Max(4, (a % 2 == 0) ? a : a + 1);
        long e = (b % 2 == 0) ? b : b - 1;
        
        long sum = 0;
        {
            if (e >= s)
            {
                long count = (e - s) / 2 + 1;
                sum = count * (e + s) / 2;
            }
        }

        Console.Write(sum);
    }
}