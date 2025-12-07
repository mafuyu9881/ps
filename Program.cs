class Program
{
    static void Main(string[] args)
    {
        // we can solve this problem with just three case works (without using loop)

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int x = tokens[0];
        int l = tokens[1];
        int r = tokens[2];
        
        int min = Math.Min(l, r);
        int max = Math.Max(l, r);

        int nearest = min;
        for (int i = min + 1; i <= max; ++i)
        {
            if (Math.Abs(x - nearest) < Math.Abs(x - i))
                break;

            nearest = i;
        }

        Console.Write(nearest);
    }
}