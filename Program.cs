internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] honeies = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int[] prefixSums = new int[n];
        prefixSums[0] = honeies[0];
        for (int i = 1; i < n; ++i)
        {
            prefixSums[i] = prefixSums[i - 1] + honeies[i];
        }

        int maxCollectedHoney = 0;
        for (int i = 1; i < n - 1; ++i)
        {
            // 벌 - 벌 - 집
            maxCollectedHoney = Math.Max(maxCollectedHoney, (prefixSums[n - 1] - honeies[0] - honeies[i]) + (prefixSums[n - 1] - prefixSums[i]));
            // 벌 - 집 - 벌
            maxCollectedHoney = Math.Max(maxCollectedHoney, (prefixSums[i] - honeies[0]) + (prefixSums[n - 2] - prefixSums[i - 1]));
            // 집 - 벌 - 벌
            maxCollectedHoney = Math.Max(maxCollectedHoney, (prefixSums[i - 1]) + (prefixSums[n - 2] - honeies[i]));
        }
        Console.Write(maxCollectedHoney);
    }
}