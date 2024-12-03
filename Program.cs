internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 100,000
        int output = 0;
        while (n > 0)
        {
            if (n % 5 != 0)
            {
                ++output;
                n -= 2;
            }
            else
            {
                output += n / 5;
                n = 0;
            }
        }
        Console.WriteLine((n != 0) ? -1 : output);
    }
}