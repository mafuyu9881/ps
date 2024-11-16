using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];
        int l = tokens[2];

        int[] cutPoints = new int[m + 1];
        for (int i = 0; i < m; ++i)
        {
            cutPoints[i] = int.Parse(Console.ReadLine()!);
        }
        cutPoints[m] = l;

        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            int cutCount = int.Parse(Console.ReadLine()!);
            int pieceCount = cutCount + 1;

            // 1 < L ≤ 4,000,000
            int low = 1 - 1;
            int high = 4000000 + 1;
            while (low < high - 1)
            {
                int mid = (low + high) / 2;

                LinkedList<int> slicedLengthLL = new();
                PriorityQueue<LinkedListNode<int>, int> slicedLengthPQ = new();
                int prevCutPoint = 0;
                for (int j = 0; j < cutPoints.Length; ++j)
                {
                    int currCutPoint = cutPoints[j];

                    int slicedLength = currCutPoint - prevCutPoint;

                    var node = slicedLengthLL.AddLast(slicedLength);
                    slicedLengthPQ.Enqueue(node, slicedLength);

                    prevCutPoint = currCutPoint;
                }

                while (slicedLengthLL.Count > pieceCount)
                {
                    var node = slicedLengthPQ.Dequeue();
                    if (node.List == null)
                        continue;

                    var prevNode = node.Previous;
                    var nextNode = node.Next;
                    LinkedListNode<int>? mergeTargetNode = prevNode;
                    if ((mergeTargetNode == null) ||
                        (nextNode != null && nextNode.Value < mergeTargetNode.Value))
                    {
                        mergeTargetNode = nextNode;
                    }

                    // there is no chance both Next and Previous are null
                    int mergedLength = node.Value + mergeTargetNode!.Value;
                    var mergedNode = slicedLengthLL.AddBefore(node, mergedLength);
                    slicedLengthPQ.Enqueue(mergedNode, mergedLength);

                    slicedLengthLL.Remove(node);
                    slicedLengthLL.Remove(mergeTargetNode);
                }

                // get rid of invalid nodes
                while (slicedLengthPQ.Peek().List == null)
                {
                    slicedLengthPQ.Dequeue();
                }

                if (mid < slicedLengthPQ.Peek().Value)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }
            output.AppendLine($"{high}");
        }
        Console.Write(output);
    }
}