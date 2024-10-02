using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = [ 2, 4, 5, 1, 3 ];

        merge_sort(arr);

        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            output.AppendLine($"{arr[i]}");
        }
        Console.Write(output);
    }

    // 버블 정렬.
    // 한 번의 순회마다 인접한 두 원소 간의 비교를 앞에서 끝까지 수행함으로써,
    // 최댓값 혹은 최소값을 배열의 끝에 차곡차곡 정리함으로써 정렬합니다.
    private static void bubble_sort(int[] arr)
    {
        int iterable_length = arr.Length - 1;

        for (int i = 0; i < iterable_length; ++i)
        {
            for (int j = 0; j < iterable_length - i; ++j)
            {
                int j_index = j;
                int next_j_index = j + 1;

                int j_element = arr[j_index];
                int next_j_element = arr[next_j_index];
                
                if (j_element > next_j_element)
                {
                    arr[j_index] = next_j_element;
                    arr[next_j_index] = j_element;
                }
            }
        }
    }

    private static void selection_sort(int[] arr)
    {
        int arr_length = arr.Length;

        for (int i = 0; i < arr_length - 1; ++i)
        {
            int selected_index = i;
            for (int j = i + 1; j < arr_length; ++j)
            {
                if (arr[selected_index] > arr[j])
                {
                    selected_index = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[selected_index];
            arr[selected_index] = temp;
        }
    }

    private static void insertion_sort_0(int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            for (int j = i; j > 0; --j)
            {
                int j_index = j;
                int prev_j_index = j - 1;
                
                int j_element = arr[j_index];
                int prev_j_element = arr[prev_j_index];

                if (prev_j_element > j_element)
                {
                    arr[j_index] = prev_j_element;
                    arr[prev_j_index] = j_element;
                }
                else
                {
                    break;
                }
            }
        }
    }

    private static void insertion_sort_1(int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            int i_element = arr[i];
            int predecessor_index = i;
            while (predecessor_index > 0)
            {
                if (arr[predecessor_index - 1] > i_element)
                {
                    arr[predecessor_index] = arr[predecessor_index - 1];
                    --predecessor_index;
                }
                else
                {
                    break;
                }
            }
            arr[predecessor_index] = i_element;
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