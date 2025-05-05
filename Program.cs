internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 100'000]

        // length = [2, 100'000]
        // element = [-100'000'000, 100'000'000]
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        //Array.Sort(sequence);

        int nearest = 200000001;
        {
            int lo = 0;
            int hi = n - 1;
            while (lo < hi)
            {
                int mixed = sequence[lo] + sequence[hi];

                if (Math.Abs(nearest) > Math.Abs(mixed))
                {
                    nearest = mixed;
                }

                if (mixed < 0)
                {
                    ++lo;
                }
                else if (mixed > 0)
                {
                    --hi;
                }
                else
                {
                    break;
                }
            }
        }
        Console.Write(nearest);
    }
}