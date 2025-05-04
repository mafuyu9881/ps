using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);
        
        StringBuilder sb = new();
        for (int i = 0; i < t; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int n = tokens[0]; // [2, 1'000'000]
            int k = tokens[1]; // [-100'000'000, 100'000'000]

            int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            Array.Sort(sequence);

            int minDistance = Math.Abs(k - (sequence[0] + sequence[n - 1]));
            int cases = 0;
            {
                int lo = 0;
                int hi = n - 1;
                while (lo < hi)
                {
                    int sum = sequence[lo] + sequence[hi];
                    int distance = Math.Abs(k - sum);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        cases = 1;
                    }
                    else if (distance == minDistance)
                    {
                        ++cases;
                    }
                    
                    if (sum < k)
                    {
                        ++lo;
                    }
                    else if (sum > k)
                    {
                        --hi;
                    }
                    else
                    {
                        ++lo;
                        --hi;
                    }
                }
            }
            sb.AppendLine($"{cases}");
        }
        Console.Write(sb);
    }
}