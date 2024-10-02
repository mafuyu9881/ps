// 시간 제한: 1초
// 메모리 제한: 128MB
// N = 2, 4, 8, 16, 32, 64, 128

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        int[] paper = new int[n * n];
        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();
            for (int j = 0; j < n; ++j)
            {
                paper[n * i + j] = int.Parse(tokens[j]);
            }
        }

        int[] paper_count = new int[2];
        compute_paper_count(paper_count, paper, n, 0, 0, n);

        Console.WriteLine(paper_count[0]);
        Console.WriteLine(paper_count[1]);
    }

    private static void compute_paper_count(int[] paper_count, int[] paper, int paper_width, int begin_row, int begin_col, int n)
    {
        int desired_color = paper[convert_index_to_1d(paper_width, begin_row, begin_col)];
        bool color_aligned = true;
        for (int row = begin_row; row < begin_row + n; ++row)
        {
            for (int col = begin_col; col < begin_col + n; ++col)
            {
                if (desired_color != paper[convert_index_to_1d(paper_width, row, col)])
                {
                    color_aligned = false;
                    break;
                }
            }
        }

        if (color_aligned)
        {
            paper_count[desired_color] += 1;
        }
        else
        {
            int half_n = n / 2;
            compute_paper_count(paper_count, paper, paper_width, begin_row, begin_col, half_n);
            compute_paper_count(paper_count, paper, paper_width, begin_row + half_n, begin_col, half_n);
            compute_paper_count(paper_count, paper, paper_width, begin_row, begin_col + half_n, half_n);
            compute_paper_count(paper_count, paper, paper_width, begin_row + half_n, begin_col + half_n, half_n);
        }
    }

    private static int convert_index_to_1d(int width, int row, int col)
    {
        return width * row + col;
    }
}