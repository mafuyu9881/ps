// Span<T>를 활용한 간결한 이진 탐색 구현

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        string[] tokens = Console.ReadLine()!.Split();

        int[] arr = new int[n];
        for (int i = 0; i < n; ++i)
        {
            arr[i] = int.Parse(tokens[i]);
        }
        merge_sort(arr);

        int m = int.Parse(Console.ReadLine()!);
        tokens = Console.ReadLine()!.Split();

        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            output.AppendLine(binary_search(arr, int.Parse(tokens[i])).ToString());
        }
        Console.Write(output);
    }

    private static int binary_search(Span<int> arr, int objective)
    {
        while (arr.Length > 0)
        {
            int mid_index = arr.Length / 2;

            if (arr[mid_index] > objective)
            {
                arr = arr.Slice(0, mid_index);
            }
            else if (arr[mid_index] < objective)
            {
                arr = arr.Slice(mid_index + 1);
            }
            else
            {
                return 1;
            }
        }

        return 0;
    }

    private static void merge_sort(Span<int> arr)
    {
        int arr_length = arr.Length;

        if (arr_length < 2)
            return;

        int mid_index = arr_length / 2;

        merge_sort(arr.Slice(0, mid_index));
        merge_sort(arr.Slice(mid_index));
        merge(arr, mid_index);
    }

    private static void merge(Span<int> arr, int mid_index)
    {
        int[] backedup = arr.ToArray();

        int arr_length = arr.Length;
        
        int left_read_index = 0;
        int right_read_index = mid_index;
        int written_index = 0;

        while (left_read_index < mid_index && right_read_index < arr_length)
        {
            if (backedup[left_read_index] < backedup[right_read_index])
            {
                arr[written_index] = backedup[left_read_index];
                ++left_read_index;
            }
            else
            {
                arr[written_index] = backedup[right_read_index];
                ++right_read_index;
            }
            ++written_index;
        }

        while (left_read_index < mid_index)
        {
            arr[written_index] = backedup[left_read_index];
            ++left_read_index;
            ++written_index;
        }
        
        while (right_read_index < arr_length)
        {
            arr[written_index] = backedup[right_read_index];
            ++right_read_index;
            ++written_index;
        }
    }
}