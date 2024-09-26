// 시간 제한: 2초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 500,000
// |입력되는 정수의 크기| ≤ 4,000
// 4B * 500,000 = 2,000,000B = 2MB

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int abs_number_limit = 4000;
        int[] counts = new int[abs_number_limit * 2 + 1];

        int n = int.Parse(Console.ReadLine()!);
        int sum = 0;
        int? min = null;
        int? max = null;
        for (int i = 0; i < n; ++i)
        {
            int number = int.Parse(Console.ReadLine()!);

            sum += number;

            if (min == null || number < min)
            {
                min = number;
            }

            if (max == null || number > max)
            {
                max = number;
            }

            ++counts[number + abs_number_limit];
        }

        int modes_count = 0;
        LinkedList<int> modes = new();
        LinkedListNode<int>? min_mode_node = null;
        int? median = null;
        int median_count = n / 2 + 1;
        int counted = 0;
        for (int number = -abs_number_limit; number <= abs_number_limit; ++number)
        {
            int count = counts[number + abs_number_limit];
            if (count < 1)
                continue;

            if (median == null)
            {
                counted += count;
                if (counted >= median_count)
                {
                    median = number;
                }
            }

            if (count > modes_count)
            {
                modes_count = count;
                modes.Clear();
                min_mode_node = modes.AddLast(number);
            }
            else if (count == modes_count)
            {
                var new_node = modes.AddLast(number);
                if (number < min_mode_node!.Value)
                {
                    min_mode_node = new_node;
                }
            }
        }

        if (modes.Count > 1)
        {
            modes.Remove(min_mode_node!);
            min_mode_node = null;
            for (var node = modes.First; node != null; node = node.Next)
            {
                if (min_mode_node == null ||
                    node.Value < min_mode_node.Value)
                {
                    min_mode_node = node;
                }
            }
        }

        StringBuilder output = new();
        output.AppendLine($"{Convert.ToInt32(Math.Round(sum / (float)n, MidpointRounding.AwayFromZero))}");
        output.AppendLine($"{median}");
        output.AppendLine($"{min_mode_node!.Value}");
        output.AppendLine($"{max - min}");
        Console.Write(output);
    }
}