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

        const int InvalidRemainM = -1;

        int low = 0 - 1;
        int high = 1000000000 + 1; // arrivalTimes.Max() + 1
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            int remainM = m;
            int elapsedTime = 0;
            int targetCowIndex = 0;
            while (targetCowIndex < arrivalTimes.Length)
            {
                while (targetCowIndex < (arrivalTimes.Length - 1) &&
                       arrivalTimes[targetCowIndex] == arrivalTimes[targetCowIndex + 1])
                {
                    targetCowIndex = targetCowIndex + 1;
                }

                int arrivalTime = arrivalTimes[targetCowIndex];

                if (arrivalTime - elapsedTime >= mid)
                {
                    remainM = Math.Max(InvalidRemainM, remainM - ((targetCowIndex / c) + 1)); // = ((((targetCowIndex + 1) - 1) / c) + 1) = ((cowCount - 1 / c) + 1);
                }

                elapsedTime = arrivalTime; // elapsedTime += (arrivalTime - elapsedTime);
                ++targetCowIndex;

                if (remainM == InvalidRemainM)
                    break;
            }

            if (remainM == InvalidRemainM)
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