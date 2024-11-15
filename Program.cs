internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int t = tokens[1];
        int[] durations = new int[n];
        for (int i = 0; i < n; ++i)
        {
            durations[i] = int.Parse(Console.ReadLine()!);
        }

        const int FailedRemainT = -1;

        int low = 0 - 1;
        int high = n + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            int remainT = t;
            if (mid > 0)
            {
                LinkedList<int> durationsInProgress = new(durations);
                while (durationsInProgress.Count > 0)
                {
                    LinkedListNode<int>?[] nodes = new LinkedListNode<int>[mid];
                    nodes[0] = durationsInProgress.First;
                    int minDuration = nodes[0]!.Value;
                    for (int i = 1; i < mid; ++i)
                    {
                        var prevNode = nodes[i - 1];
                        if (prevNode == null)
                            break;

                        var currNode = prevNode.Next;
                        if (currNode == null) // It can't be, but to prevent a compile warning.
                            break;

                        int duration = currNode.Value;
                        if (duration < minDuration)
                        {
                            minDuration = duration;
                        }

                        nodes[i] = currNode;
                    }

                    remainT = Math.Max(FailedRemainT, remainT - minDuration);
                    if (remainT == FailedRemainT)
                        break;

                    for (int i = 0; i < mid; ++i)
                    {
                        var node = nodes[i];
                        if (node == null) // It can be when the remains are less than mid.
                            break;

                        node.ValueRef -= minDuration;

                        if (node.Value > 0)
                            continue;

                        durationsInProgress.Remove(node);
                    }
                }
            }
            else
            {
                remainT = FailedRemainT;
            }

            if (remainT == FailedRemainT)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }
        Console.Write(high);
    }
}