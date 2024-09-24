// 시간 제한: 1초
// 메모리 제한: 128MB
// 1 ≤ N ≤ 100,000, 1 ≤ M ≤ 100,000
// 100,000(N) * 100,000(M) = 10,000,000,000

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        string[] n_tokens = Console.ReadLine()!.Split();

        int m = int.Parse(Console.ReadLine()!);
        string[] m_tokens = Console.ReadLine()!.Split();

        int[] arr = new int[n];
        for (int i = 0; i < n; ++i)
        {
            arr[i] = int.Parse(n_tokens[i]);
        }
        merge_sort(arr);
        
        StringBuilder output = new();
        for (int i = 0; i < m; ++i)
        {
            output.AppendLine(binary_search(arr, int.Parse(m_tokens[i])).ToString());
        }
        Console.Write(output);
    }

    private static int binary_search(int[] arr, int objective)
    {
        int arr_length = arr.Length;

        int left_read_index = 0;
        int right_read_index = arr_length - 1;

        while (left_read_index <= right_read_index)
        {
            int mid_index = left_read_index + (right_read_index - left_read_index) / 2;

            if (arr[mid_index] == objective)
            {
                return 1;
            }
            else if (arr[mid_index] < objective)
            {
                left_read_index = mid_index + 1;
            }
            else
            {
                right_read_index = mid_index - 1;
            }
        }

        return 0;
    }

    private static void merge_sort(Span<int> arr)
    {
        int arr_length = arr.Length;

        if (arr_length < 2)
            return;

        int mid = arr_length / 2;

        merge_sort(arr.Slice(0, mid));
        merge_sort(arr.Slice(mid));
        merge(arr, mid);
    }

    private static void merge(Span<int> arr, int mid)
    {
        int[] backedup = arr.ToArray();

        int arr_length = arr.Length;

        int left_read_index = 0;
        int right_read_index = mid;
        int written_index = 0;

        while (left_read_index < mid && right_read_index < arr_length)
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

        while (left_read_index < mid)
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