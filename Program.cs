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
                    else if (streak > 0)
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
        int leaves = InvalidLeaves;
        {
            bool[] visited = new bool[streaks.Length];
            int i = 0;
            int j = 0;
            int girls = 0;
            while (i < streaks.Length && j < streaks.Length)
            {
                if (visited[j] == false)
                {
                    girls += streaks[j];
                    visited[j] = true;
                }

                int boys = j - i;
                if ((girls == k) && (leaves == InvalidLeaves || boys < leaves))
                {
                    leaves = boys;
                }

                if (girls < k)
                {
                    ++j;
                }
                else
                {
                    girls -= streaks[i];
                    ++i;
                }
            }
        }
        Console.Write((leaves != InvalidLeaves) ? leaves : "NIE");
    }
}