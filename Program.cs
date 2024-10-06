using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];

        StringBuilder output = new();
        int[] sequence = new int[m];
        PrintNonduplicatedSequences(ref output,
                                    sequence,
                                    sequence,
                                    n,
                                    1);
        Console.Write(output);
    }

    private static void PrintNonduplicatedSequences(ref StringBuilder output,
                                             Span<int> sequence,
                                             Span<int> subsequence,
                                             int maximumNaturalNumber,
                                             int minimumNaturalNumber)
    {
        for (int i = minimumNaturalNumber; i <= maximumNaturalNumber; ++i)
        {
            subsequence[0] = i;

            if (subsequence.Length > 1)
            {
                PrintNonduplicatedSequences(ref output,
                                            sequence,
                                            subsequence.Slice(1),
                                            maximumNaturalNumber,
                                            i);
            }
            else
            {
                for (int j = 0; j < sequence.Length; ++j)
                {
                    output.Append($"{sequence[j]} ");
                }
                output.AppendLine();
            }
        }
    }
}