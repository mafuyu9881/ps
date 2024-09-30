// 시간 제한: 1초
// 메모리 제한: 512MB
// 0 < n < 11

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int max_n = 10;
        int n_variations_length = max_n + 1;
        int[] n_variations = new int[n_variations_length];
        n_variations[1] = 1;
        n_variations[2] = 2;
        n_variations[3] = 4;
        int memoized_index = 3;

        int t = int.Parse(Console.ReadLine()!);
        
        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);

            while (memoized_index < n)
            {
                ++memoized_index;

                n_variations[memoized_index] = n_variations[memoized_index - 1] + n_variations[memoized_index - 2] + n_variations[memoized_index - 3];
            }

            output.AppendLine($"{n_variations[n]}");
        }
        Console.Write(output);
    }
}