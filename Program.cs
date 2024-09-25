using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = [ 1, 2, 3, 4, 5 ];
        
        Console.Write(binary_search(new Span<int>(arr), 12));
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
}