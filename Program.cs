// 시간 제한: 2초
// 메모리 제한: 128MB
// 1 ≦ K ≦ 10,000
// 1 ≦ N ≦ 1,000,000

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        long k = long.Parse(tokens[0]);
        long n = long.Parse(tokens[1]);

        long[] lengths = new long[k];

        long? max_length = null;
        for (long i = 0; i < k; ++i)
        {
            long length = long.Parse(Console.ReadLine()!);

            if (max_length == null || length > max_length)
            {
                max_length = length;
            }
            
            lengths[i] = length;
        }
        
        long min_length = 1;
        long answer_length = 0;
        while (min_length <= max_length)
        {
            long mid_length = (min_length + max_length.Value) / 2;

            long cable_count = 0;
            for (long i = 0; i < k; ++i)
            {
                cable_count += lengths[i] / mid_length;
            }

            if (cable_count < n)
            {
                max_length = mid_length - 1;
            }
            else
            {
                answer_length = mid_length;
                min_length = mid_length + 1;
            }
        }
        Console.Write(answer_length);
    }
}