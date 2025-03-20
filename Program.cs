using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // [1, 100]
        int n = int.Parse(Console.ReadLine()!);

        StringBuilder[] sequences = new StringBuilder[n];
        for (int i = 0; i < sequences.Length; ++i) // max tc = 100
        {
            sequences[i] = new();
        }

        sequences[0].Append(1);

        for (int i = 1; i < sequences.Length; ++i) // max tc = 100
        {
            StringBuilder prevSequence = sequences[i - 1];
            StringBuilder currSequence = sequences[i];

            int currIndex = 0;
            int number = prevSequence[currIndex] - '0';
            int count = 1;

            while (currIndex < prevSequence.Length)
            {
                int nextIndex = currIndex + 1;

                if (nextIndex < prevSequence.Length && (prevSequence[nextIndex] - '0') == number)
                {
                    ++count;
                }
                else
                {
                    currSequence.Append(number);
                    currSequence.Append(count);

                    if (nextIndex < prevSequence.Length)
                    {
                        number = prevSequence[nextIndex] - '0';
                        count = 1;
                    }
                }

                currIndex = nextIndex;
            }
        }
    }
}