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
        MergeSort(numbers);

        StringBuilder output = new();
        bool[] occupiedIndices = new bool[numbers.Length];
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
        int numbersLength = numbers.Length;
        int subsequenceLength = subsequence.Length;

        for (int i = 0; i < numbersLength; ++i)
        {
            if (occupiedIndices[i])
                continue;

            // 중복 제거
            int iNumber = numbers[i];
            if (subsequence[0] == iNumber)
                continue;

            subsequence.Clear();

            occupiedIndices[i] = true;

            subsequence[0] = iNumber;

            if (subsequenceLength < 2)
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
    

    private static void MergeSort(Span<int> arr)
    {
        int arrLength = arr.Length;
        if (arrLength < 2)
            return;

        int midIndex = arrLength / 2;

        MergeSort(arr.Slice(0, midIndex));
        MergeSort(arr.Slice(midIndex));
        Merge(arr, midIndex);
    }

    private static void Merge(Span<int> arr, int midIndex)
    {
        int arrLength = arr.Length;
        
        int[] backedup = arr.ToArray();

        int leftReadIndex = 0;
        int rightReadIndex = midIndex;
        int writtenIndex = 0;
        
        while (leftReadIndex < midIndex && rightReadIndex < arrLength)
        {
            int leftReadElement = backedup[leftReadIndex];
            int rightReadElement = backedup[rightReadIndex];

            if (leftReadElement < rightReadElement)
            {
                arr[writtenIndex] = leftReadElement;
                ++leftReadIndex;
            }
            else
            {
                arr[writtenIndex] = rightReadElement;
                ++rightReadIndex;
            }
            ++writtenIndex;
        }

        while (leftReadIndex < midIndex)
        {
            arr[writtenIndex] = backedup[leftReadIndex];
            ++leftReadIndex;
            ++writtenIndex;
        }

        while (rightReadIndex < arrLength)
        {
            arr[writtenIndex] = backedup[rightReadIndex];
            ++rightReadIndex;
            ++writtenIndex;
        }
    }
}