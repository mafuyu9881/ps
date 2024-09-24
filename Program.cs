using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        //int[] arr = [ 5 ];
        //int[] arr = [ 5, 1 ];
        int[] arr = [ 5, 3, 4, 1, 2 ];

        merge_sort(arr);

        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            output.AppendLine(arr[i].ToString());
        }
        Console.Write(output);
    }

    private static void bubble_sort(int[] arr)
    {
        int visit_limit = arr.Length - 1;

        for (int i = 0; i < visit_limit; ++i)
        {
            for (int j = 0; j < visit_limit; ++j)
            {
                int j_element = arr[j];
                int j_1_element = arr[j + 1];

                if (j_element > j_1_element)
                {
                    arr[j] = j_1_element;
                    arr[j + 1] = j_element;
                }
            }
        }
    }

    private static void selection_sort(int[] arr)
    {
        int arr_length = arr.Length;

        for (int i = 0; i < arr_length - 1; ++i)
        {
            int? exchange_index = null;
            for (int j = i; j < arr_length; ++j)
            {
                if (exchange_index == null || arr[j] < arr[exchange_index.Value])
                {
                    exchange_index = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[exchange_index!.Value];
            arr[exchange_index!.Value] = temp;
        }
    }

    private static void insertion_sort_1(int[] arr)
    {
        int arr_length = arr.Length;

        for (int i = 1; i < arr_length; ++i)
        {
            int exchange_index = i;
            for (int j = i - 1; j > -1; --j)
            {
                int exchange_element = arr[exchange_index];
                int j_element = arr[j];
                
                if (j_element > exchange_element)
                {
                    arr[j] = exchange_element;
                    arr[exchange_index] = j_element;
                    exchange_index = j;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private static void insertion_sort_2(int[] arr)
    {
        int arr_length = arr.Length;
        
        for (int i = 1; i < arr_length; ++i)
        {
            int exchange_index = i;
            int exchange_element = arr[i];
            for (int j = i - 1; j > -1; --j)
            {
                if (arr[j] > exchange_element)
                {
                    arr[j + 1] = arr[j];
                    exchange_index = j;
                }
                else
                {
                    break;
                }
            }

            arr[exchange_index] = exchange_element;
        }
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