using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] arr = { 4, 2, 1, 5, 3 };

        counting_sort(arr);
        
        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            output.AppendLine(arr[i].ToString());
        }

        Console.Write(output);
    }

    private static void counting_sort(int[] arr)
    {
        int? max = null;

        int arr_length = arr.Length;

        for (int i = 0; i < arr_length; ++i)
        {
            int num = arr[i];

            if (max == null || num > max)
            {
                max = num;
            }
        }

        if (max == null)
            return;

        int[] counts = new int[max.Value + 1];

        for (int i = 0; i < arr_length; ++i)
        {
            ++counts[arr[i]];
        }

        int written_index = 0;
        for (int i = 1; i < counts.Length; ++i)
        {
            int count = counts[i];
            if (count < 1)
                continue;

            arr[written_index] = i;
            ++written_index;
        }
    }
}