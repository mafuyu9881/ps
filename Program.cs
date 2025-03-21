using System.Text;

internal class Program
{
    private static SortedDictionary<string, int> _tierTable = new()
    {
        { "B", 5 },
        { "S", 4 },
        { "G", 3 },
        { "P", 2 },
        { "D", 1 },
    };

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 1'000]

        // length = [2, 1'000]
        string[] tokens = Console.ReadLine()!.Split();

        LinkedList<(string tier, int level)> corrupteds = new();

        (string tier, int level)[] problems = new (string, int)[tokens.Length];
        for (int i = 0; i < problems.Length; ++i) // max tc = 1'000
        {
            string token = tokens[i];

            string tier = token.Substring(0, 1);
            int level = int.Parse(token.Substring(1));

            problems[i] = (tier, level);
        }

        for (int i = 1; i < problems.Length; ++i)
        {
            var prevProblem = problems[i - 1];
            var currProblem = problems[i];

            if (MonotonicallyIncreasing(prevProblem, currProblem) == false)
            {
                int maxProblemIndex = i - 1;
                for (int j = maxProblemIndex - 1; j >= 0; --j)
                {
                    if (MonotonicallyIncreasing(problems[maxProblemIndex], problems[j]))
                    {
                        maxProblemIndex = j;
                    }
                }

                int minProblemIndex = i;
                for (int j = minProblemIndex + 1; j < problems.Length; ++j)
                {
                    if (MonotonicallyIncreasing(problems[j], problems[minProblemIndex]))
                    {
                        minProblemIndex = j;
                    }
                }

                corrupteds.AddLast(problems[minProblemIndex]);
                corrupteds.AddLast(problems[maxProblemIndex]);

                break;
            }
        }

        StringBuilder sb = new();
        sb.AppendLine((corrupteds.Count > 0) ? "KO" : "OK");
        for (var lln = corrupteds.First; lln != null; lln = lln.Next)
        {
            sb.Append($"{lln.Value.tier}{lln.Value.level} ");
        }
        Console.Write(sb);
    }

    private static bool MonotonicallyIncreasing((string tier, int level) a, (string tier, int level) b)
    {
        if (_tierTable[b.tier] < _tierTable[a.tier])
            return true;

        if (_tierTable[b.tier] == _tierTable[a.tier] &&
            b.level <= a.level)
            return true;

        return false;
    }
}