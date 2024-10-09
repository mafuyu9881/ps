internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int n = tokens[0];
        int m = tokens[1];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int[] arr = new int[n];
        for (int i = 0; i < arr.Length; ++i)
        {
            arr[i] = tokens[i];
        }

        int left = 0;
        int right = arr.Max();
        int answer = 0;
        while (left <= right)
        {
            int mid = (left + right) >> 1;

            int intervalCount = 1;
            int min = arr[0];
            int max = arr[0];
            for (int i = 1; i < arr.Length; ++i)
            {
                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);

                if (max - min > mid)
                {
                    ++intervalCount;
                    min = arr[i];
                    max = arr[i];
                }
            }

            if (intervalCount > m)
            {
                left = mid + 1;
            }
            else
            {
                answer = mid;
                right = mid - 1;
            }
        }
        Console.Write(answer);
    }
}