class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int f = int.Parse(Console.ReadLine()!);

        for (int tens = 0; tens < 10; ++tens)
        {
            for (int ones = 0; ones < 10; ++ones)
            {
                if ((((n / 100) * 100) + (tens * 10) + (ones)) % f == 0)
                {
                    Console.Write($"{tens}{ones}");
                    return;
                }
            }
        }
    }
}