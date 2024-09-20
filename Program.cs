using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 1, 5, 3 };

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
        int arr_length = arr.Length;

        for (int i = 0; i < arr_length - 1; ++i)
        {
            for (int j = 0; j < arr_length - 1 - i; ++j)
            {
                int j_index = j;
                int next_j_index = j + 1;

                int j_element = arr[j_index];
                int next_j_element = arr[next_j_index];

                if (j_element > next_j_element)
                {
                    arr[next_j_index] = j_element;
                    arr[j_index] = next_j_element;
                }
            }
        }
    }

    private static void selection_sort(int[] arr)
    {
        int arr_length = arr.Length;

        for (int i = 0; i < arr_length; ++i)
        {
            int? exchange_index = null;
            int? exchange_element = null;
            for (int j = i; j < arr_length; ++j)
            {
                int j_element = arr[j];

                if (exchange_index == null || j_element < exchange_element)
                {
                    exchange_index = j;
                    exchange_element = arr[exchange_index.Value];
                }
            }

            arr[exchange_index!.Value] = arr[i];
            arr[i] = exchange_element!.Value;
        }
    }

    private static void insertion_sort_1(int[] arr)
    {
        for (int i = 1; i < arr.Length; ++i)
        {
            int exchange_index = i;
            for (int j = i - 1; j >= 0; --j)
            {
                // j 이전의 인덱스는 모두 정렬된 상태임이 보장됩니다.
                if (arr[j] < arr[exchange_index])
                    break;

                int temp = arr[j];
                arr[j] = arr[exchange_index];
                arr[exchange_index] = temp;
            }
        }
    }

    private static void insertion_sort_2(int[] arr)
    {
        int arr_length = arr.Length;
        
        for (int i = 1; i < arr_length; ++i)
        {
            int objective_element = arr[i];

            int exchange_index = i - 1;
            for (; exchange_index >= 0; --exchange_index)
            {
                if (arr[exchange_index] > objective_element)
                {
                    arr[exchange_index + 1] = arr[exchange_index];
                }
                else
                {
                    break;
                }
            }

            arr[exchange_index + 1] = objective_element;
        }
    }

    private static void counting_sort(int[] arr)
    {
        int arr_length = arr.Length;

        int? max_element = null;
        for (int i = 0; i < arr_length; ++i)
        {
            int i_element = arr[i];

            if (max_element == null || i_element > max_element)
            {
                max_element = i_element;
            }
        }

        if (max_element == null)
            return;

        int[] counts = new int[max_element.Value + 1];
        
        for (int i = 0; i < arr_length; ++i)
        {
            ++counts[arr[i]];
        }

        int last_written_index = 0;
        for (int i = 1; i < counts.Length; ++i)
        {
            if (counts[i] < 1)
                continue;

            arr[last_written_index] = i;
            ++last_written_index;
        }
    }

    private static void merge_sort(int[] arr)
    {
        merge_sort(new Span<int>(arr));
    }

    private static void merge_sort(Span<int> span)
    {
        int span_length = span.Length;

        if (span_length < 2)
            return;

        int middle_index = span_length / 2;

        merge_sort(span.Slice(0, middle_index));
        merge_sort(span.Slice(middle_index));
        merge(span, middle_index);
    }

    private static void merge(Span<int> span, int middle_index)
    {
        int span_length = span.Length;

        int[] backedup = span.ToArray();
        int last_written_index = 0;

        int left_read_index = 0;
        int right_read_index = middle_index;
        
        while (left_read_index < middle_index && right_read_index < span_length)
        {
            int left_read_element = backedup[left_read_index];
            int right_read_element = backedup[right_read_index];

            if (left_read_element < right_read_element)
            {
                span[last_written_index] = left_read_element;
                ++left_read_index;
            }
            else
            {
                span[last_written_index] = right_read_element;
                ++right_read_index;
            }

            ++last_written_index;
        }

        while (left_read_index < middle_index)
        {
            span[last_written_index] = backedup[left_read_index];
            ++left_read_index;
            ++last_written_index;
        }

        while (right_read_index < span_length)
        {
            span[last_written_index] = backedup[right_read_index];
            ++right_read_index;
            ++last_written_index;
        }
    }
}