using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        StringBuilder output = new();
        int[] entireSequence = new int[m];
        PrintNonduplicatedSequences(ref output, n, entireSequence, entireSequence, 0);
        Console.Write(output);
    }

    private static void PrintNonduplicatedSequences(ref StringBuilder output,
                                                      int maxNaturalNumber,
                                                      Span<int> entireSequence,
                                                      Span<int> subSequence,
                                                      int lastUsedNaturalNumber)
    {
        for (int i = lastUsedNaturalNumber + 1; i <= maxNaturalNumber; ++i)
        {
            subSequence[0] = i;

            if (subSequence.Length < 2)
            {
                for (int j = 0; j < entireSequence.Length; ++j)
                {
                    output.Append($"{entireSequence[j]} ");
                }
                output.AppendLine();
            }
            else
            {
                PrintNonduplicatedSequences(ref output,
                                            maxNaturalNumber,
                                            entireSequence,
                                            subSequence.Slice(1),
                                            i);
            }
        }
    }
}