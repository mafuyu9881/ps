// 시간 제한: 1초
// 메모리 제한: 256MB

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] tokens = Console.ReadLine()!.Split();

        int[] withdrawing_times = new int[n];
        for (int i = 0; i < n; ++i)
        {
            withdrawing_times[i] = int.Parse(tokens[i]);
        }
        merge_sort(withdrawing_times);

        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            sum += withdrawing_times[i] * (n - i);
        }
        Console.Write(sum);
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
        int arr_length = arr.Length;

        int[] backedup = arr.ToArray();

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