internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];
        
        int[] marbleCountArray = new int[m];
        for (int i = 0; i < m; ++i)
        {
            marbleCountArray[i] = int.Parse(Console.ReadLine()!);
        }

        int low = 1 - 1;
        int high = marbleCountArray.Max() + 1;
        while (low + 1 < high)
        {
            int mid = (low + high) / 2;

            int bundles = 0;
            for (int i = 0; i < marbleCountArray.Length; ++i)
            {
                bundles += ((marbleCountArray[i] - 1) / mid) + 1;
            }

            if (bundles > n)
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