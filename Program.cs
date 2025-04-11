internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000]

        const int Axes = 3;
        int[] intersectionMin = null!;
        int[] intersectionMax = null!;

        Action<int[]> ApplyToIntersectionMin = (int[] min) =>
        {
            if (intersectionMin == null)
            {
                intersectionMin = min;
            }
            else
            {
                for (int i = 0; i < Axes; ++i)
                {
                    intersectionMin[i] = Math.Max(intersectionMin[i], min[i]);
                }
            }
        };
        Action<int[]> ApplyToIntersectionMax = (int[] max) =>
        {
            if (intersectionMax == null)
            {
                intersectionMax = max;
            }
            else
            {
                for (int i = 0; i < Axes; ++i)
                {
                    intersectionMax[i] = Math.Min(intersectionMax[i], max[i]);
                }
            }
        };

        for (int i = 0; i < n; ++i) // max tc = max n = 1'000
        {
            // length = 6
            // element = [1, 1'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int[] min = new int[] { tokens[0], tokens[1], tokens[2] };
            int[] max = new int[] { tokens[3], tokens[4], tokens[5] };

            ApplyToIntersectionMin(min);
            ApplyToIntersectionMax(max);
        }

        int intersectionArea = 1;
        for (int i = 0; i < Axes; ++i)
        {
            int diff = intersectionMax[i] - intersectionMin[i];
            if (diff > 0)
            {
                intersectionArea *= diff;
            }
            else
            {
                intersectionArea = 0;
                break;
            }
        }
        Console.Write(intersectionArea);
    }
}