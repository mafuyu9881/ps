class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int maxPrizeMoney = 0;
        for (int i = 0; i < n; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int a = tokens[0];
            int b = tokens[1];
            int c = tokens[2];

            int prizeMoney = 0;
            if (a == b && b == c)
            {
                prizeMoney = 10000 + a * 1000;
            }
            else if (a == b)
            {
                prizeMoney = 1000 + a * 100;
            }
            else if (b == c)
            {
                prizeMoney = 1000 + b * 100;
            }
            else if (c == a)
            {
                prizeMoney = 1000 + c * 100;
            }
            else
            {
                prizeMoney = Math.Max(a, Math.Max(b, c)) * 100;
            }
            
            maxPrizeMoney = Math.Max(prizeMoney, maxPrizeMoney);
        }

        Console.Write(maxPrizeMoney);
    }
}