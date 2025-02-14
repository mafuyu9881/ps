using System.Text;

internal class Program
{
    private class Node
    {
        private int _data;
        public int Data => _data;
        private Node? _parent;
        private LinkedList<Node> _children;
        public LinkedList<Node> Children => _children;
        private LinkedList<Node> _unboundChildren;
        public LinkedList<Node> UnboundChildren => _unboundChildren;

        public Node(int data)
        {
            _data = data;
            _parent = null;
            _children = new();
            _unboundChildren = new();
        }

        public void SetParent(Node parent)
        {
            // update child's data
            _parent = parent;

            // update parent's data
            parent._children.AddLast(this);
            parent._unboundChildren.AddLast(this);
        }

        public void RemoveFromParent()
        {
            // just indicate that the child is bound from now on
            // don't remove from the actual list (_children)
            _parent!._unboundChildren.Remove(this); // max tc = 333'333
        }
    }

    private static Node _root = new(0);
    private static Node[] _nodes = null!;
    private static PriorityQueue<string, int> _bounds = new();

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [3, 333'333]

        _nodes = new Node[n + 1];
        for (int i = 1; i < _nodes.Length; ++i)
        {
            _nodes[i] = new(i);
        }
        _nodes[1].SetParent(_root);

        for (int i = 0; i < n - 1; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int u = tokens[0];
            int v = tokens[1];
            _nodes[v].SetParent(_nodes[u]);
        }

        TryBind(_nodes[1]);

        StringBuilder sb = new();
        if (_root.UnboundChildren.Count > 0)
        {
            sb.AppendLine("U");
        }
        else
        {
            sb.AppendLine("S");
            while (_bounds.Count > 0)
            {
                sb.AppendLine(_bounds.Dequeue());
            }
        }
        Console.Write(sb);
    }

    private static void TryBind(Node node)
    {
        for (var childLLN = node.Children.First; childLLN != null; childLLN = childLLN.Next)
        {
            TryBind(childLLN.Value);
        }

        if (TryBindAsCase1(node) || TryBindAsCase2(node))
        {
            node.RemoveFromParent();
        }
    }

    // case 1
    // * <- here
    // |
    // *
    // |
    // *
    private static bool TryBindAsCase1(Node grandParent)
    {
        var unboundParents = grandParent.UnboundChildren;
        if (unboundParents.Count != 1)
            return false;

        Node unboundParent = unboundParents.First!.Value;
        var unboundChildren = unboundParent.UnboundChildren;
        if (unboundChildren.Count != 1)
            return false;

        Node unboundChild = unboundChildren.First!.Value;
        if (unboundChild.UnboundChildren.Count > 0)
            return false;

        PriorityQueue<int, int> pq = new();
        pq.Enqueue(grandParent.Data, grandParent.Data);
        pq.Enqueue(unboundParent.Data, unboundParent.Data);
        pq.Enqueue(unboundChild.Data, unboundChild.Data);

        int primary = pq.Dequeue();
        int secondary = pq.Dequeue();
        int tertiary = pq.Dequeue();

        _bounds.Enqueue($"{primary} {secondary} {tertiary}", primary);

        return true;
    }

    // case 2
    //   * <- here
    //  / \
    // *   *
    private static bool TryBindAsCase2(Node parent)
    {
        var unboundChildren = parent.UnboundChildren;
        if (unboundChildren.Count != 2)
            return false;

        var unboundChild0 = unboundChildren.First!.Value;
        if (unboundChild0.UnboundChildren.Count > 0)
            return false;

        var unboundChild1 = unboundChildren.Last!.Value;
        if (unboundChild1.UnboundChildren.Count > 0)
            return false;

        PriorityQueue<int, int> pq = new();
        pq.Enqueue(parent.Data, parent.Data);
        pq.Enqueue(unboundChild0.Data, unboundChild0.Data);
        pq.Enqueue(unboundChild1.Data, unboundChild1.Data);

        int primary = pq.Dequeue();
        int secondary = pq.Dequeue();
        int tertiary = pq.Dequeue();

        _bounds.Enqueue($"{primary} {secondary} {tertiary}", primary);

        return true;
    }
}