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

        StringBuilder output = new();
        Solver(output, selectables, m, 0, 0, 0);
        Console.Write(output);
    }

    private static void Solver(StringBuilder output,
                               int[] selectables,
                               int sequenceLength,
                               int leastSelectableIndex,
                               int recursionDepth,
                               int sequence)
    {
        int newRecursionDepth = recursionDepth + 1;

        int placeExponent = sequenceLength - recursionDepth;
        int place = ExponentiationBySquaringIteratively(10, placeExponent);

        for (int i = leastSelectableIndex; i < selectables.Length; ++i)
        {
            int newSequence = sequence + i * place;

            if (newRecursionDepth < sequenceLength)
            {
                Solver(output,
                       selectables,
                       sequenceLength,
                       i,
                       newRecursionDepth,
                       newSequence);
            }
            else
            {
                for (int j = sequenceLength; j > 0; --j) // max tc = 8
                {
                    int placeForPrinting = ExponentiationBySquaringIteratively(10, j); // max tc = log2(8)
                    output.Append($"{selectables[(newSequence % (placeForPrinting * 10)) / placeForPrinting]} ");
                }
                output.AppendLine();
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