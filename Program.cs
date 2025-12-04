class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int k = int.Parse(Console.ReadLine()!);

        int nextMonthQuota = k + 60;
        int withinQuota = Math.Min(n, nextMonthQuota);
        int extraQuota = Math.Max(0, n - nextMonthQuota);

        Console.Write(withinQuota * 1500 + extraQuota * 3000);
    }
}