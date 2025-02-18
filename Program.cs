internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 10'000]
        int l = tokens[1]; // [1, 1'000'000]

        (int s, int e)[] puddles = new (int, int)[n];
        for (int i = 0; i < n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            puddles[i] = (tokens[0], tokens[1]);
        }

        MergeSort(puddles);
        
        int used = 0;
        int currEnd = 0;
        for (int i = 0; i < puddles.Length; ++i)
        {
            var puddle = puddles[i];

            if (currEnd >= puddles[puddles.Length - 1].e)
                break;

            if (currEnd < puddle.s)
                currEnd = puddle.s;

            int lengthToCover = puddle.e - currEnd; // on the end index is not the part of the puddle
            int required = lengthToCover / l;
            if (lengthToCover % l > 0)
                required += 1;

            used += required;
            currEnd += required * l;
        }

        Console.Write(used);
    }

    private static void MergeSort(Span<(int s, int e)> span)
    {
        int spanLength = span.Length;
        if (spanLength < 2)
            return;

        int mid = spanLength / 2;

        MergeSort(span.Slice(0, mid));
        MergeSort(span.Slice(mid));
        Merge(span, mid);
    }

    private static void Merge(Span<(int s, int e)> span, int mid)
    {
        int containerLength = span.Length;

        var backedup = span.ToArray();

        int leftReadIndex = 0;
        int rightReadIndex = mid;
        int writtenIndex = 0;

        while (leftReadIndex < mid && rightReadIndex < containerLength)
        {
            var leftElement = backedup[leftReadIndex];
            var rightElement = backedup[rightReadIndex];
            if (leftElement.s < rightElement.s)
            {
                span[writtenIndex] = leftElement;
                ++leftReadIndex;
            }
            else
            {
                span[writtenIndex] = rightElement;
                ++rightReadIndex;
            }
            ++writtenIndex;
        }
        
        while (leftReadIndex < mid)
        {
            span[writtenIndex] = backedup[leftReadIndex];
            ++leftReadIndex;
            ++writtenIndex;
        }

        while (rightReadIndex < containerLength)
        {
            span[writtenIndex] = backedup[rightReadIndex];
            ++rightReadIndex;
            ++writtenIndex;
        }
    }
}