internal class Program
{
    private static void Main(string[] args)
    {
        const int Girl = 0;

        int[] nk = Array.ConvertAll(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        int n = nk[0]; // [1, 1'000'000]
        int k = nk[1]; // [1, n] = [1, 1'000'000]

        int[] line = Array.ConvertAll(Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        int[] streaks = null!;
        {
            LinkedList<int> temp = new();
            {
                int streak = 0;
                for (int i = 0; i < line.Length; ++i)
                {
                    if (line[i] == Girl)
                    {
                        ++streak;
                    }
                    else
                    {
                        temp.AddLast(streak);
                        streak = 0;
                    }
                }

                if (streak > 0)
                {
                    temp.AddLast(streak);
                    streak = 0;
                }
            }
            streaks = temp.ToArray();
        }

        const int InvalidLeaves = -1;
        int lefts = InvalidLeaves;
        {
            for (int i = 0; i < streaks.Length; ++i)
            {
                int girls = 0;
                for (int j = i; j < streaks.Length; ++j)
                {
                    girls += streaks[j];

                    if (girls > k)
                    {
                        break;
                    }
                    else if (girls == k)
                    {
                        int boys = j - i;
                        if (lefts == InvalidLeaves || lefts > boys)
                        {
                            lefts = boys;
                        }
                    }
                }
            }
        }
        Console.Write((lefts != InvalidLeaves) ? lefts : "NIE");
    }
}