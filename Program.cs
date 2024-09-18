using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // 1 <= k, n <= 14이므로, 집의 최대 수는 196, 각 집마다 거주민 수를 구하기 위해 다른 모든 집을 순회한다고 하더라도 196 * 196 = 38416.
        // 최적화 고민을 다소 내려놓아도 풀리는 문제다.
        
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();

        for (int i = 0; i < t; ++i)
        {
            // 층 수는 0부터 시작합니다.
            int rows = int.Parse(Console.ReadLine()!) + 1;
            int cols = int.Parse(Console.ReadLine()!);

            int rooms_length = rows * cols;
            int[] rooms = new int[rooms_length];

            for (int j = 0; j < rooms_length; ++j)
            {
                int row = j / cols;
                int col = j % cols;

                int population;
                if (row == 0)
                {
                    // 호 수는 1부터 시작하므로, 최소 한 명부터 시작합니다.
                    population = col + 1;
                }
                else
                {
                    population = 0;

                    ReadOnlySpan<int> queried_rooms = new ReadOnlySpan<int>(rooms, j - cols - col, col + 1);
                    for (int q = 0; q < queried_rooms.Length; ++q)
                    {
                        population += queried_rooms[q];
                    }
                }

                rooms[row * cols + col] = population;
            }

            output.AppendLine(rooms[rooms_length - 1].ToString());
        }

        Console.Write(output);
    }
}