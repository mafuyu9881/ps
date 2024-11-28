internal class Program
{
    private static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine()!);

        int currACount = 1;
        int currBCount = 0;

        for (int i = 0; i < k; ++i)
        {
            int prevACount = currACount;
            int prevBCount = currBCount;

            currACount = prevBCount;
            currBCount = prevACount + prevBCount;
        }

        Console.Write($"{currACount} {currBCount}");
    }
}