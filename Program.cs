using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        tokens = Console.ReadLine()!.Split();
        
        int[] numbers = new int[n];
        for (int i = 0; i < n; ++i)
        {
            numbers[i] = int.Parse(tokens[i]);
        }
        Array.Sort(numbers);

        StringBuilder output = new();
        int[] sequence = new int[m];
        PrintNonduplicatedSequences(ref output,
                                    numbers,
                                    sequence,
                                    sequence,
                                    -1);
        Console.Write(output);
    }

    private static void PrintNonduplicatedSequences(ref StringBuilder output,
                                                    Span<int> numbers,
                                                    Span<int> sequence,
                                                    Span<int> subsequence,
                                                    int lastReadNumberIndex)
    {
        for (int i = lastReadNumberIndex + 1; i < numbers.Length; ++i)
        {
            subsequence[0] = numbers[i];

            if (subsequence.Length < 2)
            {
                for (int j = 0; j < sequence.Length; ++j)
                {
                    output.Append($"{sequence[j]} ");
                }
                output.AppendLine();
            }
            else
            {
                PrintNonduplicatedSequences(ref output, numbers, sequence, subsequence.Slice(1), i);
            }
        }
    }
}