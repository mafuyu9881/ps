// 시간 제한: 2초
// 메모리 제한: 512MB
// 1 ≤ N ≤ 1,000,000
// -10^9 ≤ X[i] ≤ 10^9

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        string[] tokens = Console.ReadLine()!.Split();

        // 최대 시복 = 1,000,000
        int[] inputNumbers = new int[n];
        int[] sortedInputNumbers = new int[n];
        int[] uniqueSortedInputNumbers = new int[n];
        for (int i = 0; i < tokens.Length; ++i)
        {
            int inputNumber = int.Parse(tokens[i]);
            inputNumbers[i] = inputNumber;
            sortedInputNumbers[i] = inputNumber;
        }
        // 최대 시복 = Nlog
        MergeSort(sortedInputNumbers);

        // 최대 시복 = (1,000,000)log(1,000,000) ≈ 18,000,000 ~ 19,000,000
        int uniqueSortedInputNumbersCount = 0;
        for (int i = 0; i < n; ++i)
        {
            int sortedInputNumber = sortedInputNumbers[i];

            if (i > 0 && sortedInputNumbers[i - 1] == sortedInputNumber)
                continue;

            uniqueSortedInputNumbers[uniqueSortedInputNumbersCount] = sortedInputNumber;
            ++uniqueSortedInputNumbersCount;
        }

        StringBuilder output = new();
        for (int i = 0; i < inputNumbers.Length; ++i)
        {
            int inputNumber = inputNumbers[i];

            int left = 0;
            int right = uniqueSortedInputNumbersCount;
            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (inputNumber < uniqueSortedInputNumbers[mid])
                {
                    right = mid - 1;
                }
                else if (inputNumber > uniqueSortedInputNumbers[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    output.Append($"{mid} ");
                    break;
                }
            }
        }
        Console.Write(output);
    }

    private static void MergeSort(Span<int> span)
    {
        int spanLength = span.Length;

        if (spanLength < 2)
            return;

        int midIndex = spanLength / 2;

        MergeSort(span.Slice(0, midIndex));
        MergeSort(span.Slice(midIndex));
        Merge(span, midIndex);
    }

    private static void Merge(Span<int> span, int midIndex)
    {
        int spanLength = span.Length;

        int[] backedup = span.ToArray();

        int leftReadIndex = 0;
        int rightReadIndex = midIndex;
        int writtenIndex = 0;

        while (leftReadIndex < midIndex && rightReadIndex < spanLength)
        {
            if (backedup[leftReadIndex] < backedup[rightReadIndex])
            {
                span[writtenIndex] = backedup[leftReadIndex];
                ++leftReadIndex;
            }
            else
            {
                span[writtenIndex] = backedup[rightReadIndex];
                ++rightReadIndex;
            }
            ++writtenIndex;
        }

        while (leftReadIndex < midIndex)
        {
            span[writtenIndex] = backedup[leftReadIndex];
            ++leftReadIndex;
            ++writtenIndex;
        }

        while (rightReadIndex < spanLength)
        {
            span[writtenIndex] = backedup[rightReadIndex];
            ++rightReadIndex;
            ++writtenIndex;
        }
    }
}