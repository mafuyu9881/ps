internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];
        
        int[] timeTakens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        long low = 1 - 1;
        long high = (long)timeTakens.Max() * m + 1;
        while (low < high - 1)
        {
            long mid = (low + high) / 2;

            long remainM = m;
            for (int i = 0; i < n; ++i)
            {
                remainM -= (int)(mid / timeTakens[i]);
            }

            if (remainM > 0)
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