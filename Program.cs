using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // tc = 2
        int n = tokens[0];
        int m = tokens[1];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // max tc = 8
        SortedSet<int> sorter = new();
        for (int i = 0; i < tokens.Length; ++i) // max tc = 8
        {
            sorter.Add(tokens[i]);
        }

        int[] selectables = new int[sorter.Count];
        for (int i = 0; i < selectables.Length; ++i) // max tc = 8
        {
            int min = sorter.Min; // max tc = log2(8)
            selectables[i] = min;
            sorter.Remove(min);
        }

        LinkedList<int> sequences = new();
        Solver(sequences, selectables.Length, m, 0, 0, 0);

        StringBuilder output = new();
        for (var node = sequences.First; node != null; node = node.Next)
        {
            for (int i = m; i > 0; --i) // max tc = 8
            {
                int place = ExponentiationBySquaringIteratively(10, i);
                // selectables의 인덱스를 참조해야할듯
                output.Append($"{selectables[(node.Value % (place * 10)) / place]} ");
            }
            output.AppendLine();
        }
        Console.Write(output);
    }

    private static void Solver(LinkedList<int> sequences,
                               int selectablesLength,
                               int sequenceLength,
                               int leastSelectableIndex,
                               int recursionDepth,
                               int sequence)
    {
        int newRecursionDepth = recursionDepth + 1;

        int placeExponent = sequenceLength - recursionDepth;
        int place = ExponentiationBySquaringIteratively(10, placeExponent);

        for (int i = leastSelectableIndex; i < selectablesLength; ++i)
        {
            int newSequence = sequence + i * place;

            if (newRecursionDepth < sequenceLength)
            {
                Solver(sequences,
                       selectablesLength,
                       sequenceLength,
                       i,
                       newRecursionDepth,
                       newSequence);
            }
            else
            {
                sequences.AddLast(newSequence);
            }
        }
    }

    private static int ExponentiationBySquaringIteratively(int basis, int exponent)
    {
        int output = 1;
        while (exponent > 0)
        {
            if ((exponent & 1) == 1)
            {
                output *= basis;
            }
            basis *= basis;
            exponent >>= 1;
        }
        return output;
    }
}