// 4byte * 1,000,000 = 4,000,000 = 4megabyte
// 공간 복잡도에 대한 고민은 하지 않아도 좋은 것으로 보인다.
// 1,000,000 * 1,000,000 = 1,000,000,000,000
// 다만 시간 제한이 2초이기 때문에, 시간 복잡도에 대한 고민이 요구되는 것으로 생각된다.

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] arr = new int[n];

        for (int i = 0; i < n; ++i)
        {
            arr[i] = int.Parse(Console.ReadLine()!);
        }

        merge_sort(arr);
        
        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            output.AppendLine(arr[i].ToString());
        }

        Console.WriteLine(output);
    }

    private static void merge_sort(int[] arr)
    {
        merge_sort(new Span<int>(arr));
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