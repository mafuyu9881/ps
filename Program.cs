internal class Program
{
    private static void Main(string[] args)
    {
        const int Ryan = 1;

        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 1'000'000]
        int k = tokens[1]; // [1, n] = [1, 1'000'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] dolls = new int[n];
        for (int i = 0; i < dolls.Length; ++i)
        {
            dolls[i] = tokens[i];
        }

        List<int> ryanIndices = new(dolls.Length);
        for (int i = 0; i < dolls.Length; ++i)
        {
            if (dolls[i] == Ryan)
            {
                ryanIndices.Add(i);
            }
        }

        const int Invalid = -1;
        int minLength = Invalid;
        {
            for (int i = 0; i + k - 1 < ryanIndices.Count; ++i)
            {
                int length = ryanIndices[i + k - 1] - ryanIndices[i] + 1;
                if (minLength == Invalid || minLength > length)
                {
                    minLength = length;
                }
            }
        }
        Console.Write(minLength);
    }
}