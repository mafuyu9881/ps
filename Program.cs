using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100]
        // length = [1, n] = [1, 100]
        // element = [1, 100]
        int[] seqA = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int m = int.Parse(Console.ReadLine()!); // [1, 100]
        // length = [1, m] = [1, 100]
        // element = [1, 100]
        int[] seqB = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int[,] dp = new int[n + 1, m + 1];
        for (int row = 1; row < dp.GetLength(0); ++row) // max tc = 100
        {
            for (int col = 1; col < dp.GetLength(1); ++col) // max tc = 100
            {
                int seqAIndex = row - 1;
                int seqBIndex = col - 1;

                int streaks;
                if (seqA[seqAIndex] == seqB[seqBIndex])
                {
                    streaks = dp[row - 1, col - 1] + 1;
                }
                else
                {
                    streaks = Math.Max(dp[row - 1, col], dp[row, col - 1]);
                }
                dp[row, col] = streaks;
            }
        }

        LinkedList<int> lcs = new();
        {
            int row = dp.GetLength(0) - 1;
            int col = dp.GetLength(1) - 1;
            
            while (row > 0 && col > 0)
            {
                // It is guaranteed that currStreaks is greater than or equal to both leftStreaks and upStreaks
                int currStreaks = dp[row, col];
                int leftStreaks = dp[row, col - 1];
                int aboveStreaks = dp[row - 1, col];

                if (currStreaks == leftStreaks)
                {
                    --col;
                }
                else if (currStreaks == aboveStreaks)
                {
                    --row;
                }
                else
                {
                    lcs.AddLast(seqA[row - 1]);
                    --row;
                    --col;
                }
            }
        }
        
        if (lcs.Count > 0)
        {
            LinkedListNode<int>? currLLN = lcs.Last;
            while (currLLN != null)
            {
                LinkedListNode<int>? PrevLLN = currLLN.Previous;

                for (var lln = PrevLLN; lln != null; lln = lln.Previous)
                {
                    if (lln.Value > currLLN.Value)
                    {
                        lcs.Remove(currLLN);
                        break;
                    }
                }

                currLLN = PrevLLN;
            }
        }
        
        StringBuilder sb = new();
        sb.AppendLine($"{lcs.Count}");
        for (var lln = lcs.Last; lln != null; lln = lln.Previous)
        {
            sb.Append($"{lln.Value} ");
        }
        Console.Write(sb);
    }
}