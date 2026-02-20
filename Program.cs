class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];

        int[] sequence = new int[b + 1];
        {
            int writingIndex = 1;
            for (int number = 1; writingIndex < sequence.Length; ++number)
            {
                for (int i = 0; i < number && writingIndex < sequence.Length; ++i)
                {
                    sequence[writingIndex] = number;
                    ++writingIndex;
                }
            }
        }

        int sum = 0;
        {
            for (int i = a; i < sequence.Length; ++i)
            {
                sum += sequence[i];
            }
        }

        Console.Write(sum);
    }
}