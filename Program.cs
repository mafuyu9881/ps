// 시간 제한: 1초
// 메모리 제한: 256MB
// 1 ≤ N ≤ 1,000
// 1 ≤ (집합의 원소) ≤ 1,000

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        string[] tokens = Console.ReadLine()!.Split();

        int[] sequence = new int[n];
        for (int i = 0; i < n; ++i)
        {
            sequence[i] = int.Parse(tokens[i]);
        }
        
        int maxCombo = 1;
        ComputeMaxCombo(ref maxCombo,
                        0,
                        null,
                        sequence);
        Console.Write(maxCombo);
    }

    private static void ComputeMaxCombo(ref int maxCombo,
                                        int prevCombo,
                                        int? prevNumber,
                                        Span<int> sequence)
    {
        int sequenceLength = sequence.Length;

        for (int i = 0; i < sequenceLength; ++i)
        {
            int currNumber = sequence[i];
            if (prevNumber == null || currNumber > prevNumber)
            {
                int currCombo = prevCombo + 1;

                if (currCombo > maxCombo)
                {
                    maxCombo = currCombo;
                }

                int nextBeginIndex = i + 1;
                if (nextBeginIndex < sequenceLength)
                {
                    ComputeMaxCombo(ref maxCombo,
                                    currCombo,
                                    currNumber,
                                    sequence.Slice(nextBeginIndex));
                }
            }
        }
    }
}