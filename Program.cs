// 시간 제한: 0.25초
// 메모리 제한: 128MB

using System.Text;
using CallCount = System.Tuple<int, int>;

internal class Program
{
    private static void Main(string[] args)
    {
        int max_n = 40;
        int callcounts_length = max_n + 1;

        CallCount[] callcounts = new CallCount[callcounts_length];
        callcounts[0] = new(1, 0);
        callcounts[1] = new(0, 1);

        int callcounts_written_index = 1;

        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);
            
            while (callcounts_written_index < n)
            {
                ++callcounts_written_index;

                // p == previous
                CallCount pp_callcount = callcounts[callcounts_written_index - 2];
                CallCount p_callcount = callcounts[callcounts_written_index - 1];

                callcounts[callcounts_written_index] = new(pp_callcount.Item1 + p_callcount.Item1, pp_callcount.Item2 + p_callcount.Item2);
            }

            CallCount n_callcount = callcounts[n];
            output.AppendLine($"{n_callcount.Item1} {n_callcount.Item2}");
        }
        Console.Write(output);
    }
}