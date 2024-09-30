// 시간 제한: 1초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 100,000
// 1 ≤ M ≤ 100,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        tokens = Console.ReadLine()!.Split();

        int[] accumulations = new int[n];
        for (int i = 0; i < n; ++i)
        {
            int number = int.Parse(tokens[i]);

            int prev_accumulation = 0;
            if (i > 0)
                prev_accumulation = accumulations[i - 1];

            accumulations[i] = prev_accumulation + number;
        }

        StringBuilder output = new();
        for (int k = 0; k < m; ++k)
        {
            tokens = Console.ReadLine()!.Split();

            int i = int.Parse(tokens[0]) - 1;
            int j = int.Parse(tokens[1]) - 1;
            int prefix_sum = accumulations[j];
            if (i > 0)
            {
                // 'j'까지의 누적합에서 'i - 1'까지의 누적합을 빼면 'i' ~ 'j'의 구간합과 같습니다.
                prefix_sum -= accumulations[i - 1];
            }

            output.AppendLine($"{prefix_sum}");
        }
        Console.Write(output);
    }
}