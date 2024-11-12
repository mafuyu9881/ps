internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int s = tokens[0];
        int c = tokens[1];

        long[] springOnions = new long[s];
        for (int i = 0; i < s; ++i)
        {
            springOnions[i] = int.Parse(Console.ReadLine()!);
        }

        long low = 1 - 1;
        long high = springOnions.Max() + 1;
        while (low < high - 1)
        {
            long mid = (low + high) / 2;

            long distributed = 0;
            for (int i = 0; i < s; ++i)
            {
                distributed += springOnions[i] / mid;
            }

            if (distributed < c)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        Console.Write(springOnions.Sum() - (low * c));
    }
}