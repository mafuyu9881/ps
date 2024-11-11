internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidLandingPosition = -1;
        const int RangeStart = 0;
        const int RangeEnd = 1000000000;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int k = tokens[1];

        int[] hayBalePositions = new int[n];
        for (int i = 0; i < n; ++i)
        {
            hayBalePositions[i] = int.Parse(Console.ReadLine()!);
        }
        Array.Sort(hayBalePositions);

        int low = 1 - 1;
        int high = RangeEnd / 2 + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            int shoots = 0;
            int lastLandingPosition = InvalidLandingPosition;
            for (int i = 0; i < hayBalePositions.Length; ++i)
            {
                int hayBalePosition = hayBalePositions[i];

                if ((lastLandingPosition == InvalidLandingPosition) ||
                    (hayBalePosition > lastLandingPosition + mid))
                {
                    lastLandingPosition = Math.Clamp(hayBalePosition + mid, RangeStart + mid, RangeEnd - mid);
                    ++shoots;
                }
            }

            if (shoots > k)
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