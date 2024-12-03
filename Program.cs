internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int mine = int.Parse(Console.ReadLine()!);
        
        int[] candidates = new int[n - 1]; // n = (0..50]
        int candidatesLength = candidates.Length;
        for (int i = 0; i < candidates.Length; ++i)
        {
            candidates[i] = int.Parse(Console.ReadLine()!);
        }
        Array.Sort(candidates);

        int output = 0;
        if (candidatesLength > 0)
        {
            int lastCandidatesIndex = candidatesLength - 1;
            while (mine <= candidates[lastCandidatesIndex])
            {
                ++mine;
                --candidates[lastCandidatesIndex];
                ++output;
                Array.Sort(candidates);
            }
        }
        Console.Write(output);
    }
}