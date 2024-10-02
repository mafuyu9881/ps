// 시간 제한: 1초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 1,000,000, 1 ≤ M ≤ 2,000,000,000

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        tokens = Console.ReadLine()!.Split();
        int max_tree_height = 0;
        int[] tree_heights = new int[n];
        for (int i = 0; i < n; ++i)
        {
            int height = int.Parse(tokens[i]);
            max_tree_height = Math.Max(height, max_tree_height);
            tree_heights[i] = height;
        }

        int left_index = 0;
        int right_index = max_tree_height;
        int cutting_height = 0;
        while (left_index <= right_index)
        {
            int mid_index = (left_index + right_index) / 2;

            long cut_sum = 0;
            for (int i = 0; i < tree_heights.Length; ++i)
            {
                cut_sum += Math.Max(tree_heights[i] - mid_index, 0);
            }

            if (cut_sum < m)
            {
                right_index = mid_index - 1;
            }
            else
            {
                cutting_height = mid_index;
                left_index = mid_index + 1;
            }
        }
        Console.Write(cutting_height);
    }
}