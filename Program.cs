internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 1'000'000]
        int k = tokens[1]; // [1, 100'000]

        // element = [1, 1'000'000]
        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int s = 0;
        int e = 0;

        int longestLength = 0;
        LinkedList<int> oddIndices = new();
        while (true) // max tc = 1'000'000
        {
            int newLength = e - s + 1 - oddIndices.Count;
            if (sequence[s] % 2 == 1)
                --newLength;

            longestLength = Math.Max(longestLength, newLength);
            
            ++e;

            if (e > sequence.Length - 1)
                break;

            if (sequence[e] % 2 == 1)
                oddIndices.AddLast(e);

            if (oddIndices.Count > k)
            {
                var lln = oddIndices.First!;
                s = lln.Value;
                oddIndices.Remove(lln);
            }
        }
        Console.Write(longestLength);
    }
}