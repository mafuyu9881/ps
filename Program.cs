internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];

        int[] runningTimes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int low = 1 - 1;
        int high = runningTimes.Sum() + 1;
        while (low + 1 < high)
        {
            int mid = (low + high) / 2;

            int blurayCount = 1;
            int blurayRunningTime = 0;
            for (int i = 0; i < runningTimes.Length; ++i)
            {
                int runningTime = runningTimes[i];

                if (runningTime > mid)
                {
                    blurayCount = m + 1; // 실패 처리
                    break;
                }
                else
                {
                    blurayRunningTime += runningTime;

                    if (blurayRunningTime > mid)
                    {
                        blurayRunningTime = runningTime;
                        ++blurayCount;
                    }
                }
            }

            if (blurayCount > m)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }
        Console.Write(high);
    }
}