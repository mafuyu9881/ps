internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] sequence = new int[n];
        int[] lisLengths = new int[n];
        int[] ldsLengths = new int[n];
        for (int i = 0; i < n; ++i)
        {
            sequence[i] = int.Parse(Console.ReadLine()!);
            lisLengths[i] = 1;
            ldsLengths[i] = 1;
        }
        
        int output = 0;
        for (int i = n - 1; i > -1; --i)
        {
            int iElement = sequence[i];

            for (int j = i + 1; j < n; ++j)
            {
                int jElement = sequence[j];

                if (iElement < jElement)
                {
                    lisLengths[i] = Math.Max(lisLengths[j] + 1, lisLengths[i]);
                }

                if (iElement > jElement)
                {
                    ldsLengths[i] = Math.Max(ldsLengths[j] + 1, ldsLengths[i]);
                }
            }

            output = Math.Max(output, lisLengths[i] + ldsLengths[i] - 1);
        }
        Console.Write(output);
    }
}