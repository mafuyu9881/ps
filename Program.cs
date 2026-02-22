class Program
{
    static void Main(string[] args)
    {
        string yeondu = Console.ReadLine()!;

        int n = int.Parse(Console.ReadLine()!);

        List<string> teams = new();
        for (int i = 0; i < n; ++i)
        {
            teams.Add(Console.ReadLine()!);
        }

        string bestTeam = "";
        int bestScore = -1;
        for (int i = 0; i < teams.Count; ++i)
        {
            string team = teams[i];

            int score = GetScore(yeondu, team);

            if (score > bestScore)
            {
                bestScore = score;
                bestTeam = team;
            }
            else if (score == bestScore)
            {
                if (string.Compare(team, bestTeam, StringComparison.Ordinal) < 0)
                {
                    bestTeam = team;
                }
            }
        }

        Console.Write(bestTeam);
    }

    static void CountLOVE(string s, ref int lCount, ref int oCount, ref int vCount, ref int eCount)
    {
        for (int i = 0; i < s.Length; ++i)
        {
            char c = s[i];
            if (c == 'L')
            {
                ++lCount;
            }
            else if (c == 'O')
            {
                ++oCount;
            }
            else if (c == 'V')
            {
                ++vCount;
            }
            else if (c == 'E')
            {
                ++eCount;
            }
        }
    }

    static int GetScore(string a, string b)
    {
        int lCount = 0;
        int oCount = 0;
        int vCount = 0;
        int eCount = 0;

        CountLOVE(a, ref lCount, ref oCount, ref vCount, ref eCount);
        CountLOVE(b, ref lCount, ref oCount, ref vCount, ref eCount);

        return (int)
        (
            (long)(lCount + oCount) *
            (lCount + vCount) *
            (lCount + eCount) *
            (oCount + vCount) *
            (oCount + eCount) *
            (vCount + eCount)
        ) % 100;
    }
}