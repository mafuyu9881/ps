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

        long sum = savours[0];
        {
            for (int i = 0; i < k - 1; ++i)
            {
                int j = savours.Length - 1 - i;
                if (j < 0)
                    break;

                sum += savours[j] - savours[0];
            }
        }
        Console.Write(sum);
    }
}