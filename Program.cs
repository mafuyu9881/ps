internal class Program
{
    private static void Main(string[] args)
    {
        string c = Console.ReadLine()!;
        string s = Console.ReadLine()!;

        int cnt = 0;
        {
            int streaks = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                char token = s[i];

                if (token == c[streaks])
                {
                    ++streaks;
                }

                if (streaks == c.Length)
                {
                    streaks = 0;
                    ++cnt;
                }
            }
        }
        Console.Write(cnt);
    }
}