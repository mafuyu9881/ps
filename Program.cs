internal class Program
{
    private static void Main(string[] args)
    {
        const int Girl = 0;

        int[] nk = Array.ConvertAll(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        int n = nk[0]; // [1, 1'000'000]
        int k = nk[1]; // [1, n] = [1, 1'000'000]

        int[] line = Array.ConvertAll(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        int[] girlIndices = null!;
        {
            LinkedList<int> temp = new();
            for (int i = 0; i < line.Length; ++i)
            {
                if (line[i] == Girl)
                {
                    temp.AddLast(i);
                }
            }
            girlIndices = temp.ToArray();
        }

        const int InvalidLefts = -1;
        int lefts = InvalidLefts;
        {
            int windowSize = k;
            for (int i = 0; i + k - 1 < girlIndices.Length; ++i)
            {
                int beginGirlIndex = girlIndices[i];
                int endGirlIndex = girlIndices[i + k - 1];

                // k is equal to the number of girls in the window
                int boys = (endGirlIndex - beginGirlIndex + 1) - k;

                if (lefts == InvalidLefts || lefts > boys)
                {
                    lefts = boys;
                }
            }
        }
        Console.Write((lefts != InvalidLefts) ? lefts : "NIE");
    }
}