// 시간 제한: 1초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 1,000
// 1 ≤ (집합의 원소) ≤ 1,000

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        string[] tokens = Console.ReadLine()!.Split();

        int[] sequence = new int[n];
        int[] lisLengths = new int[n];
        for (int i = 0; i < n; ++i)
        {
            sequence[i] = int.Parse(tokens[i]);
            lisLengths[i] = 1;
        }
        
        int maxLISLength = 1;
        for (int i = 1; i < n; ++i)
        {
            for (int j = 0; j < i; ++j)
            {
                if (sequence[j] < sequence[i])
                {
                    int lisLength = Math.Max(lisLengths[i], lisLengths[j] + 1);

                    lisLengths[i] = lisLength;

                    maxLISLength = Math.Max(maxLISLength, lisLength);
                }
            }
        }
        Console.Write(maxLISLength);
    }
}