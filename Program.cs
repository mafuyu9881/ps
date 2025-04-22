internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 300'000]
        int k = tokens[1]; // [1, n] = [1, 300'000]

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] savours = new int[tokens.Length];
        for (int i = 0; i < savours.Length; ++i)
        {
            savours[i] = tokens[i];
        }
        Array.Sort(savours);

        long sum = savours[tokens.Length - 1];
        {
            int i = 0;
            int j = tokens.Length - 2;
            k -= 1;
            while (i < j && k > 1)
            {
                sum += savours[j] - savours[i];

                ++i;
                --j;
                k -= 2;
            }
        }
        Console.Write(sum);
    }
}