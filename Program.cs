internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int m = tokens[0];
        int n = tokens[1];

        int[] snackLengths = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int low = 1 - 1;
        int high = snackLengths.Max() + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            int snackCount = 0;
            for (int i = 0; i < n; ++i)
            {
                snackCount += snackLengths[i] / mid;
            }

            if (snackCount < m)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        Console.Write(low);
    }
}