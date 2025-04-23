internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 200'000]
        int k = tokens[1]; // [1, 100]

        // length = [1, n] = [1, 200'000]
        // element = [1, 100'000]
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int[] sequence = new int[tokens.Length];
        for (int i = 0; i < sequence.Length; ++i)
        {
            sequence[i] = tokens[i];
        }

        int maxLength = 1;
        {
            int i = 0;
            int j = 0;

            int duplicated = 0;

            int[] counts = new int[100000 + 1];
            Action<int> AddCount = (number) =>
            {
                ++counts[number];

                if (counts[number] == k + 1)
                {
                    ++duplicated;
                }
            };
            Action<int> RemoveCount = (number) =>
            {
                if (counts[number] == k + 1)
                {
                    --duplicated;
                }

                --counts[number];
            };

            AddCount(sequence[j]);
            
            while (true)
            {
                if (duplicated > 0)
                {
                    RemoveCount(sequence[i]);
                    ++i;
                }
                else
                {
                    maxLength = Math.Max(maxLength, j - i + 1);

                    ++j;

                    if (j < sequence.Length)
                    {
                        AddCount(sequence[j]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        Console.Write(maxLength);
    }
}