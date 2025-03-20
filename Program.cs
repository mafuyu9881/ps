internal class Program
{
    private static void Main(string[] args)
    {
        // [1, 100]
        int n = int.Parse(Console.ReadLine()!);

        LinkedList<int>[] sequences = new LinkedList<int>[n];
        for (int i = 0; i < sequences.Length; ++i) // max tc = 100
        {
            sequences[i] = new();
        }

        sequences[0].AddLast(1);

        for (int i = 1; i < sequences.Length; ++i) // max tc = 100
        {
            LinkedList<int> prevSequence = sequences[i - 1];
            LinkedList<int> currSequence = sequences[i];

            LinkedListNode<int>? currLLN = prevSequence.First!;
            int number = currLLN.Value;
            int count = 1;
            while (currLLN != null)
            {
                LinkedListNode<int>? nextLLN = currLLN.Next;

                if (nextLLN != null && nextLLN.Value == number)
                {
                    ++count;
                }
                else
                {
                    currSequence.AddLast(number);
                    currSequence.AddLast(count);

                    if (nextLLN != null)
                    {
                        number = nextLLN.Value;
                        count = 1;
                    }
                }
                
                currLLN = nextLLN;
            }
        }
    }
}