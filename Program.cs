// 시간 제한: 1초
// 메모리 제한: 1024MB

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        if (n == 0)
        {
            Console.Write(0);
            return;
        }

        int[] ratings = new int[n];

        int trimmed = Convert.ToInt32(Math.Round(n * 0.15f, MidpointRounding.AwayFromZero));

        for (int i = 0; i < n; ++i)
        {
            ratings[i] = int.Parse(Console.ReadLine()!);
        }

        merge_sort(ratings);

        float average_rating = 0.0f;
        for (int i = trimmed; i < n - trimmed; ++i)
        {
            average_rating += ratings[i];
        }
        average_rating /= n - trimmed * 2;

        Console.Write(Convert.ToInt32(Math.Round(average_rating, MidpointRounding.AwayFromZero)));
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
            int left_read_element = backedup[left_read_index];
            int right_read_element = backedup[right_read_index];

            if (left_read_element < right_read_element)
            {
                arr[written_index] = left_read_element;
                ++left_read_index;
            }
            else
            {
                arr[written_index] = right_read_element;
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