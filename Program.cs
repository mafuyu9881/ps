using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        StringBuilder output = new();
        PrintNonduplicatedSequences(ref output, n, m, null, -1, 0);
        Console.Write(output);
    }

    private static void PrintNonduplicatedSequences(ref StringBuilder output,
                                                      int maxNaturalNumber,
                                                      int sequenceLength,
                                                      int[]? sequence,
                                                      int lastWrittenIndex,
                                                      int lastUsedNaturalNumber)
    {
        int writingIndex = lastWrittenIndex + 1;

        for (int i = lastUsedNaturalNumber + 1; i <= maxNaturalNumber; ++i)
        {
            //if (lastWrittenIndex == -1)
            if (sequence == null)
                sequence = new int[sequenceLength];

            sequence[writingIndex] = i;

            //if (writingIndex >= sequence.GetUpperBound(0))
            if (writingIndex >= sequenceLength - 1)
            {
                for (int j = 0; j < sequenceLength; ++j)
                {
                    output.Append($"{sequence[j]} ");
                }
                output.AppendLine();
            }
            else
            {
                PrintNonduplicatedSequences(ref output, maxNaturalNumber, sequenceLength, sequence, writingIndex, i);
            }
        }
    }
}