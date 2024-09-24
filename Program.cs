using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = [ 5, 3, 2, 1, 4 ];
        
        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            output.AppendLine(binary_search(arr, 1).ToString());
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
}