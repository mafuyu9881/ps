internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];
        int c = tokens[2];
        int[] arrivalTimes = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        Array.Sort(arrivalTimes);
        
        int low = 0 - 1;
        int high = 1000000000 + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            int remainM = m - 1;
            int waitingCowIndex = 0; // cows corresponding to indices prior to this value have already boarded the bus
            for (int i = 0; i < n; ++i)
            {
                int waitingCowCount = i - waitingCowIndex + 1;
                int waitingTime = arrivalTimes[i] - arrivalTimes[waitingCowIndex];

                if (waitingCowCount > c || waitingTime > mid)
                {
                    waitingCowIndex = i;
                    --remainM;
                }
            }

            if (remainM < 0)
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