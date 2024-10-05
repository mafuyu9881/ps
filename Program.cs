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
        bool[] occupiedIndices = new bool[n];
        int[] sequence = new int[m];
        PrintNonduplicatedSequences(ref output,
                                    ref occupiedIndices,
                                    numbers,
                                    sequence,
                                    sequence);
        Console.Write(output);
    }

    private static void PrintNonduplicatedSequences(ref StringBuilder output,
                                                    ref bool[] occupiedIndices,
                                                    Span<int> numbers,
                                                    Span<int> sequence,
                                                    Span<int> subsequence)
    {
        for (int i = 0; i < numbers.Length; ++i)
        {
            if (occupiedIndices[i])
                continue;
            
            occupiedIndices[i] = true;

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
                PrintNonduplicatedSequences(ref output,
                                            ref occupiedIndices,
                                            numbers,
                                            sequence,
                                            subsequence.Slice(1));
            }

            occupiedIndices[i] = false;
        }
    }
}