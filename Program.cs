using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 100]
        int m = tokens[1]; // [1, 100]

        int[][] cards = new int[n][];
        for (int i = 0; i < n; ++i) // max tc = 100
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            cards[i] = new int[m];
            for (int j = 0; j < m; ++j) // max tc = 100
            {
                cards[i][j] = tokens[j];
            }
            Array.Sort(cards[i], (x, y) => y.CompareTo(x));
        }

        int maxScore = 0;
        int[] scores = new int[n];
        for (int i = 0; i < m; ++i) // max tc = 100
        {
            int maxCard = 0;
            for (int j = 0; j < n; ++j) // max tc = 100
            {
                maxCard = Math.Max(maxCard, cards[j][i]);
            }

            for (int j = 0; j < n; ++j) // max tc = 100
            {
                if (cards[j][i] == maxCard)
                {
                    ++scores[j];
                    maxScore = Math.Max(maxScore, scores[j]);
                }
            }
        }

        LinkedList<int> maxScorePlayerLL = new();
        for (int i = 0; i < n; ++i)
        {
            if (scores[i] == maxScore)
            {
                maxScorePlayerLL.AddLast(i + 1);
            }
        }

        int[] maxScorePlayers = maxScorePlayerLL.ToArray();
        Array.Sort(maxScorePlayers);

        StringBuilder sb = new();
        for (int i = 0; i < maxScorePlayers.Length; ++i)
        {
            sb.Append($"{maxScorePlayers[i]} ");
        }
        Console.Write(sb);
    }
}