internal class Program
{
    private static void Main(string[] args)
    {
        string token = Console.ReadLine()!; // [1, 999'999'999]

        int minOddCount = int.MaxValue;
        int maxOddCount = 0;

        Action<string, int> Operate = null!;
        Operate = (sn, oddCount) =>
        {
            oddCount += CountOdd(sn);

            if (sn.Length == 1)
            {
                minOddCount = Math.Min(minOddCount, oddCount);
                maxOddCount = Math.Max(maxOddCount, oddCount);
            }
            else if (sn.Length == 2)
            {
                int a = int.Parse(sn.Substring(0, 1));
                int b = int.Parse(sn.Substring(1, 1));
                Operate((a + b).ToString(), oddCount);
            }
            else
            {
                for (int l0 = 1; l0 < sn.Length - 1; ++l0)
                {
                    for (int l1 = 1; l0 + l1 < sn.Length; ++l1)
                    {
                        int a = int.Parse(sn.Substring(0, l0));
                        int b = int.Parse(sn.Substring(l0, l1));
                        int c = int.Parse(sn.Substring(l0 + l1));
                        Operate((a + b + c).ToString(), oddCount);
                    }
                }
            }
        };

        Operate(token, 0);

        Console.Write($"{minOddCount} {maxOddCount}");
    }
    
    private static int CountOdd(string sn)
    {
        int oddCount = 0;
        for (int i = 0; i < sn.Length; ++i)
        {
            if (int.Parse(sn.Substring(i, 1)) % 2 == 1)
            {
                ++oddCount;
            }
        }
        return oddCount;
    }
}