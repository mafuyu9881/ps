// 시간 제한: 1초
// 메모리 제한: 512MB
// 1 ≤ width, height ≤ 50
// 1 ≤ tno_cabbages ≤ 2500

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();

            int width = int.Parse(tokens[0]);
            int height = int.Parse(tokens[1]);
            int tno_cabbages = int.Parse(tokens[2]);
            
            bool[] farmland = new bool[width * height];

            HashSet<int> planted_indices = new();

            for (int j = 0; j < tno_cabbages; ++j)
            {
                tokens = Console.ReadLine()!.Split();

                int col = int.Parse(tokens[0]);
                int row = int.Parse(tokens[1]);
                int index = convert_index_to_1d(width, new(row, col));

                farmland[index] = true;

                planted_indices.Add(index);
            }

            LinkedList<HashSet<int>> connected_cabbages_list = new();
            while (planted_indices.Count > 0)
            {
                int initial_index = planted_indices.First();
                planted_indices.Remove(initial_index);

                Queue<int> traversal_queue = new();
                traversal_queue.Enqueue(initial_index);

                HashSet<int> visited_indices = new();
                visited_indices.Add(initial_index);

                HashSet<int> connected_cabbages = new();
                connected_cabbages_list.AddLast(connected_cabbages);

                while (traversal_queue.Count > 0)
                {
                    int origin_index = traversal_queue.Dequeue();
                    Index2D origin_index_2d = convert_index_to_2d(width, origin_index);
                    connected_cabbages.Add(origin_index);

                    Index2D[] adjacent_indices = new Index2D[]
                    {
                        new Index2D(origin_index_2d.row - 1, origin_index_2d.col),
                        new Index2D(origin_index_2d.row, origin_index_2d.col - 1),
                        new Index2D(origin_index_2d.row + 1, origin_index_2d.col),
                        new Index2D(origin_index_2d.row, origin_index_2d.col + 1),
                    };

                    for (int j = 0; j < adjacent_indices.Length; ++j)
                    {
                        Index2D adjacent_index_2d = adjacent_indices[j];
                        if (is_valid_index(width, height, adjacent_index_2d) == false)
                            continue;

                        int adjacent_index = convert_index_to_1d(width, adjacent_index_2d);
                        if (traversal_queue.Contains(adjacent_index))
                            continue;

                        if (visited_indices.Contains(adjacent_index))
                            continue;

                        if (farmland[adjacent_index] == false)
                            continue;

                        traversal_queue.Enqueue(adjacent_index);
                        visited_indices.Add(adjacent_index);
                        planted_indices.Remove(adjacent_index);
                    }
                }
            }

            output.AppendLine($"{connected_cabbages_list.Count}");
        }
        Console.Write(output);
    }

    private static int convert_index_to_1d(int width, Index2D index)
    {
        return width * index.row + index.col;
    }

    private static Index2D convert_index_to_2d(int width, int index)
    {
        return new(index / width, index % width);
    }

    private static bool is_valid_index(int width, int height, int index)
    {
        return is_valid_index(
            width,
            height,
            convert_index_to_2d(width, index));
    }

    private static bool is_valid_index(int width, int height, Index2D index)
    {
        if (index.col < 0 || index.col > width - 1)
            return false;

        if (index.row < 0 || index.row > height - 1)
            return false;

        return true;
    }
}

public struct Index2D
{
    public int row;
    public int col;

    public Index2D(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}