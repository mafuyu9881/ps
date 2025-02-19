using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 20]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 20
        {
            Span<int> span = new(Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse)); // max tc = 10'001

            int n = span[0]; // (0, 10'000]
            int[] sequence = span.Slice(1).ToArray();

            int[] prefixSum = new int[sequence.Length];
            for (int j = 0; j < prefixSum.Length; ++j) // max tc = 10'000
            {
                prefixSum[j] = sequence[j];

                if (j > 0)
                {
                    prefixSum[j] += prefixSum[j - 1];
                }
            }

            int lo = 2 - 1; // the minimum length of primed subsequence is 2
            int hi = prefixSum.Length + 1; // [1, 10'000]
            LinkedList<int> subsequence = new();
            while (lo + 1 < hi) // max tc = log2(10'000) = 13.xxx
            {
                int mid = (lo + hi) / 2;

                bool succeeded = false;
                for (int j = 0; j < prefixSum.Length - (mid - 1); ++j) // max tc = 10'000
                {
                    int sum = prefixSum[j + (mid - 1)] - prefixSum[j] + sequence[j];
                    if (Prime(sum))
                    {
                        succeeded = true;

                        subsequence.Clear();
                        for (int k = j; k < j + mid; ++k)
                        {
                            subsequence.AddLast(sequence[k]);
                        }

                        break;
                    }
                }

                if (succeeded)
                {
                    hi = mid;
                }
                else
                {
                    lo = mid;
                }
            }

            if (subsequence.Count > 0)
            {
                sb.Append($"Shortest primed subsequence is length {subsequence.Count}: ");
                for (var lln = subsequence.First; lln != null; lln = lln.Next)
                {
                    sb.Append($"{lln.Value} ");
                }
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("This sequence is anti-primed.");
            }
        }
        Console.Write(sb);
    }
    
    private static bool Prime(int n)
    {
        if (n < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(n); ++i) // max tc = sqrt(10'000 * 10'000) = 10'000
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}