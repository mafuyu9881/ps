// 시간 제한: 1초
// 메모리 제한: 128MB
// 1 ≤ N ≤ 100,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int max_n = 100000;
        int n = int.Parse(Console.ReadLine()!);
        
        int[] min_heap = new int[max_n];
        int written_index = -1;
        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int x = int.Parse(Console.ReadLine()!);

            if (x != 0)
            {
                int writing_index = written_index + 1;
                min_heap[writing_index] = x;

                while (true)
                {
                    int parent_index = writing_index / 2;
                    if (writing_index % 2 == 0)
                        parent_index -= 1;

                    if (parent_index < 0)
                        break;

                    int parent_data = min_heap[parent_index];
                    int writing_data = min_heap[writing_index];
                    if (parent_data <= writing_data)
                        break;

                    min_heap[parent_index] = writing_data;
                    min_heap[writing_index] = parent_data;
                    writing_index = parent_index;
                }

                ++written_index;
            }
            else
            {
                if (written_index < 0)
                {
                    output.AppendLine("0");
                }
                else
                {
                    output.AppendLine($"{min_heap[0]}");

                    int writing_index = 0;
                    min_heap[writing_index] = min_heap[written_index];

                    while (true)
                    {
                        int? left_index = writing_index * 2 + 1;
                        int? right_index = writing_index * 2 + 2;
                        
                        if (left_index > written_index)
                            left_index = null;

                        if (right_index > written_index)
                            right_index = null;

                        int next_writing_index = writing_index;

                        if (left_index != null &&
                            min_heap[left_index.Value] < min_heap[next_writing_index])
                        {
                            next_writing_index = left_index.Value;
                        }

                        if (right_index != null &&
                            min_heap[right_index.Value] < min_heap[next_writing_index])
                        {
                            next_writing_index = right_index.Value;
                        }

                        if (next_writing_index == writing_index)
                            break;
                        
                        int temp = min_heap[writing_index];
                        min_heap[writing_index] = min_heap[next_writing_index];
                        min_heap[next_writing_index] = temp;

                        writing_index = next_writing_index;
                    }

                    --written_index;
                }
            }
        }
        Console.Write(output);
    }
}