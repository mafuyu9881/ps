internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int l = tokens[1] - 1; // [1 - 1, r - 1]
        int r = tokens[2] - 1; // [l - 1, n - 1]

        int[] sequence = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int answer = 0;

        int min = sequence[l];
        int max = sequence[l];
        for (int i = l + 1; i <= r; ++i)
        {
            min = Math.Min(min, sequence[i]);
            max = Math.Max(max, sequence[i]);
        }

        for (int i = 0; i < l; ++i)
        {
            if (sequence[i] > min)
            {
                goto Print;
            }
        }

        for (int i = r + 1; i < sequence.Length; ++i)
        {
            if (sequence[i] < max)
            {
                goto Print;
            }
        }

        answer = 1;

Print:
        Console.Write(answer);
    }
}