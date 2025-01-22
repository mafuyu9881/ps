internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 50'000]

        // x = [0, 1'000'000'000]
        // id = [0, 1'000'000'000]
        PriorityQueue<(int x, int id), int> pqX = new();
        SortedSet<int> ids = new();
        for (int i = 0; i < n; ++i) // max tc = 50'000
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x = tokens[0];
            int id = tokens[1];
            pqX.Enqueue((x, id), x); // max tc = log2(50'000) = 15.xxxx
            ids.Add(id);
        }

        LinkedList<(int x, int id)> cows = new();
        while (pqX.Count > 0) // max tc = 50'000
        {
            cows.AddLast(pqX.Dequeue());
        }

        int output = 0;
        int low = 1 - 1;
        int high = 1000000000 + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2; // [1, 1'000'000'000]

            SortedDictionary<int, int> takenIDs = new();
            LinkedListNode<(int x, int id)> beginCowNode = cows.First!;
            LinkedListNode<(int x, int id)> endCowNode = cows.First!;
            while (true)
            {
                var endCow = endCowNode.Value;
                int endCowID = endCow.id;
                int endCowX = endCow.x;

                if (takenIDs.ContainsKey(endCowID) == false)
                {
                    takenIDs.Add(endCowID, 0);
                }
                ++takenIDs[endCowID];

                while (endCowX - beginCowNode.Value.x > mid)
                {
                    var beginCow = beginCowNode.Value;
                    int beginCowID = beginCow.id;

                    --takenIDs[beginCowID];
                    if (takenIDs[beginCowID] < 1)
                    {
                        takenIDs.Remove(beginCowID);
                    }

                    beginCowNode = beginCowNode.Next!;
                }

                if (takenIDs.Count == ids.Count || endCowNode == cows.Last!)
                {
                    break;
                }
                else
                {
                    endCowNode = endCowNode.Next!;
                }
            }

            if (takenIDs.Count == ids.Count)
            {
                high = mid;
                output = mid;
            }
            else
            {
                low = mid;
            }
        }
        Console.Write(output);
    }
}