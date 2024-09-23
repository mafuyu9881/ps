// 2 ≤ N ≤ 50, 10 ≤ x, y ≤ 200

using System.Text;
using Size = System.Tuple<int, int>;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        Size[] sizes = new Size[n];
        
        for (int i = 0; i < n; ++i)
        {
            string[] size_token = Console.ReadLine()!.Split();

            sizes[i] = new Size(int.Parse(size_token[0]), int.Parse(size_token[1]));
        }

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            var size_i = sizes[i];

            int rank_i = 1;
            for (int j = 0; j < n; ++j)
            {
                if (i == j)
                    continue;

                var size_j = sizes[j];
                if (size_j.Item1 > size_i.Item1 && size_j.Item2 > size_i.Item2)
                {
                    ++rank_i;
                }
            }

            output.Append($"{rank_i} ");
        }

        Console.Write(output);
    }
}