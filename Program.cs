using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] nm = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = nm[0]; // [1, 1'000'000]
        int m = nm[1]; // [1, 1'000'000]

        int[] a = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] b = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int[] combined = new int[n + m];
        {
            int aReadIndex = 0;
            int bReadIndex = 0;
            int writingIndex = 0;
            while (writingIndex < combined.Length)
            {
                if (aReadIndex > n - 1)
                {
                    combined[writingIndex] = b[bReadIndex];
                    ++bReadIndex;
                }
                else if (bReadIndex > m - 1)
                {
                    combined[writingIndex] = a[aReadIndex];
                    ++aReadIndex;
                }
                else // `aReadIndex > n - 1 && bReadIndex > m - 1` can't happen in this context
                {
                    int aElement = a[aReadIndex];
                    int bElement = b[bReadIndex];
                    if (aElement >= bElement)
                    {
                        combined[writingIndex] = bElement;
                        ++bReadIndex;
                    }
                    else
                    {
                        combined[writingIndex] = aElement;
                        ++aReadIndex;
                    }
                }
                ++writingIndex;
            }
        }

        StringBuilder sb = new();
        for (int i = 0; i < combined.Length; ++i)
        {
            sb.Append($"{combined[i]} ");
        }
        Console.Write(sb);
    }
}