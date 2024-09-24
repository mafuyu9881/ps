// 시간 제한: 1초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 100,000
// -100,000 ≤ xi, yi ≤ 100,000
// 2B * 15(한 줄의 예상 최대 길이) * 100,000 = 3,000,000B = 3MB

using System.Text;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        Point[] arr = new Point[n];

        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();

            Point point = new();
            point.X = int.Parse(tokens[0]);
            point.Y = int.Parse(tokens[1]);

            arr[i] = point;
        }

        merge_sort(arr);

        StringBuilder output = new();
        for (int i = 0; i < arr.Length; ++i)
        {
            Point point = arr[i];
            output.AppendLine($"{point.X} {point.Y}");
        }
        Console.Write(output);
    }
    
    private static void merge_sort(Span<Point> arr)
    {
        int arr_length = arr.Length;

        if (arr_length < 2)
            return;

        int mid = arr_length / 2;

        merge_sort(arr.Slice(0, mid));
        merge_sort(arr.Slice(mid));
        merge(arr, mid);
    }

    private static void merge(Span<Point> arr, int mid)
    {
        Point[] backedup = arr.ToArray();

        int arr_length = arr.Length;

        int left_read_index = 0;
        int right_read_index = mid;
        int written_index = 0;

        while (left_read_index < mid && right_read_index < arr_length)
        {
            Point left_read_point = backedup[left_read_index];
            Point right_read_point = backedup[right_read_index];

            if (left_read_point.Y < right_read_point.Y ||
               (left_read_point.Y == right_read_point.Y &&
                left_read_point.X < right_read_point.X))
            {
                arr[written_index] = left_read_point;
                ++left_read_index;
            }
            else
            {
                arr[written_index] = right_read_point;
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