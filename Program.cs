internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 200,000

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // 1 ≤ Si ≤ 9

        int begin = 0;
        int end = 0;

        const int InvalidIndex = -1;
        int[] lastIndexOfIncluded = new int[10];
        for (int i = 0; i < lastIndexOfIncluded.Length; ++i)
        {
            lastIndexOfIncluded[i] = InvalidIndex;
        }
        LinkedList<int> includedNumbers = new();

        int maximumLength = 0;
        int length = 0;
        while (end < tokens.Length)
        {
            int number = tokens[end];

            if (lastIndexOfIncluded[number] != InvalidIndex)
            {
                ++length;
                lastIndexOfIncluded[number] = end;
            }
            else
            {
                if (includedNumbers.Count < 2)
                {
                    ++length;
                }
                else
                {
                    var firstNode = includedNumbers.First!;
                    var secondNode = includedNumbers.Last!;
                    LinkedListNode<int> pendingNode = firstNode;
                    if (lastIndexOfIncluded[firstNode.Value] > lastIndexOfIncluded[secondNode.Value])
                    {
                        pendingNode = secondNode;
                    }

                    int pendingNumber = pendingNode.Value;
                    begin = lastIndexOfIncluded[pendingNumber] + 1;
                    lastIndexOfIncluded[pendingNumber] = InvalidIndex;
                    includedNumbers.Remove(pendingNode);

                    length = end - begin + 1;
                }

                lastIndexOfIncluded[number] = end;
                includedNumbers.AddLast(number);
            }

            maximumLength = Math.Max(maximumLength, length);
            ++end;
        }
        Console.Write(maximumLength);
    }
}