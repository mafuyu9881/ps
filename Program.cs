internal class Program
{
    private struct ChildConnectionData
    {
        private int _child;
        public int Child => _child;
        private int _cost;
        public int Cost => _cost;

        public ChildConnectionData(int child, int cost)
        {
            _child = child;
            _cost = cost;
        }
    }

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // 1 ≤ n ≤ 10,000
        int extendedN = n + 1;

        LinkedList<ChildConnectionData>[] childrenList = new LinkedList<ChildConnectionData>[extendedN];
        for (int i = 1; i < extendedN; ++i) // tc = n
        {
            childrenList[i] = new();
        }
        LinkedList<int> visitableParents = new();
        for (int i = 0; i < n; ++i) // tc = n
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int parent = tokens[0];
            int child = tokens[1];
            int cost = tokens[2];

            visitableParents.AddLast(parent);
            childrenList[parent].AddLast(new ChildConnectionData(child, cost));
        }

        //int[] diameters = new int[extendedN];
        int maxDiameter = 0;
        while (true)
        {
            if (visitableParents.Count < 1)
                break;

            var node = visitableParents.First!;
            int parent = node.Value;
            visitableParents.Remove(node);

            int diameter = 0;

            Queue<ChildConnectionData> ccdQueue = new();
            var adjs = childrenList[parent];
            for (var iteratingNode = adjs.First; iteratingNode != null; iteratingNode = iteratingNode.Next)
            {
                ccdQueue.Enqueue(iteratingNode.Value);
            }
            while (ccdQueue.Count > 0)
            {
                ChildConnectionData ccd = ccdQueue.Dequeue();

                diameter += ccd.Cost;

                int child = ccd.Child;

                var leftGrandchildNode = childrenList[child].First;
                var rightGrandchildNode = childrenList[child].Last;
                if (leftGrandchildNode == null) // same semantics with 'if (leftGrandchildNode == null && rightGrandchildNode == null)'
                    continue;

                if (leftGrandchildNode != rightGrandchildNode)
                {
                    int leftCost = leftGrandchildNode.Value.Cost;
                    int rightCost = rightGrandchildNode.Value.Cost;
                }
                else // child has only one node
                {
                    ccdQueue.Enqueue(leftGrandchildNode.Value);
                }
            }

            if (diameter > maxDiameter)
            {
                maxDiameter = diameter;
            }
        }
    }
}