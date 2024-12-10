internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        // 1 ≤ a, b < 1000, a ≠ b
        int a = tokens[0];
        int b = tokens[1];

        // 1 ≤ n ≤ 5
        int n = int.Parse(Console.ReadLine()!);
        int[] frequencies = new int[n];
        for (int i = 0; i < frequencies.Length; ++i)
        {
            frequencies[i] = int.Parse(Console.ReadLine()!);
        }

        int output = 0;
        while (a != b)
        {
            int newA;

            int leftA = a - 1;
            int rightA = a + 1;
            if (Math.Abs(b - leftA) < Math.Abs(b - rightA))
            {
                newA = leftA;
            }
            else
            {
                newA = rightA;
            }

            for (int i = 0; i < frequencies.Length; ++i)
            {
                int frequency = frequencies[i];
                if (Math.Abs(b - frequency) < Math.Abs(b - newA))
                {
                    newA = frequency;
                }
            }

            a = newA;
            ++output;
        }
        Console.Write(output);
    }
}