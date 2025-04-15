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

        LinkedList<int>[,] csList = new LinkedList<int>[n + 1, m + 1]; // cs = common sequence
        for (int row = 0; row < csList.GetLength(0); ++row) // max tc = 101
        {
            for (int col = 0; col < csList.GetLength(1); ++col) // max tc = 101
            {
                csList[row, col] = new();
            }
        }

        for (int row = 1; row < csList.GetLength(0); ++row) // max tc = 100
        {
            for (int col = 1; col < csList.GetLength(1); ++col) // max tc = 100
            {
                int elemA = seqA[row - 1];
                int elemB = seqB[col - 1];
                if (elemA == elemB)
                {
                    LinkedList<int> prevCS = csList[row - 1, col - 1];
                    for (var lln = prevCS.First; lln != null; lln = lln.Next) // max tc = 100
                    {
                        int elem = lln.Value;
                        if (elem < elemA)
                            break;

                        csList[row, col].AddLast(elem);
                    }
                    csList[row, col].AddLast(elemA);
                }
                else
                {
                    csList[row, col] = GetGreaterSequence(csList[row - 1, col], csList[row, col - 1]);
                }
            }
        }

        StringBuilder sb = new();
        {
            var cs = csList[csList.GetLength(0) - 1, csList.GetLength(1) - 1];
            sb.AppendLine($"{cs.Count}");
            for (var lln = cs.First; lln != null; lln = lln.Next)
            {
                sb.Append($"{lln.Value} ");
            }
        }
        Console.Write(sb);
    }

    private static LinkedList<int> GetGreaterSequence(LinkedList<int> s1, LinkedList<int> s2)
    {
        if (s1 == null)
            return s2;

        if (s2 == null)
            return s1;

        var s1LLN = s1.First;
        var s2LLN = s2.First;
        while (s1LLN != null && s2LLN != null)
        {
            if (s1LLN.Value > s2LLN.Value)
                return s1;

            if (s1LLN.Value < s2LLN.Value)
                return s2;

            s1LLN = s1LLN.Next;
            s2LLN = s2LLN.Next;
        }

        if (s1.Count > s2.Count)
            return s1;

        if (s1.Count < s2.Count)
            return s2;
        
        return s1;
    }
}