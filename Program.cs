using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = [5, 2, 3, 1, 4];

        merge_sort(arr);

        for (int i = 0; i < arr.Length; ++i)
        {
            Console.WriteLine(arr[i]);
        }
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
            int min_index = i;
            for (int j = i + 1; j < arr_length; ++j)
            {
                if (arr[j] < arr[min_index])
                {
                    min_index = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[min_index];
            arr[min_index] = temp;
        }
    }

    private static void insertion_sort_1(int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            int insertion_index = i;
            for (int j = i - 1; j >= 0; --j)
            {
                if (arr[j] > arr[insertion_index])
                {
                    int temp = arr[j];
                    arr[j] = arr[insertion_index];
                    arr[insertion_index] = temp;
                    insertion_index = j;
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
        for (int i = 1; i < arr.Length; ++i)
        {
            int insertion_element = arr[i];
            int predecessor_index = i - 1;
            for (; predecessor_index >= 0; --predecessor_index)
            {
                if (arr[predecessor_index] > insertion_element)
                {
                    arr[predecessor_index + 1] = arr[predecessor_index];
                }
                else
                {
                    break;
                }
            }
            arr[predecessor_index + 1] = insertion_element;
        }
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