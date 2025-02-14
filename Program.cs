internal class Program
{
    private class Node
    {
        private int _data;
        public int Data => _data;
        private Node? _parent;
        private LinkedList<Node> _children;
        public LinkedList<Node> Children => _children;

        public Node(int data)
        {
            _data = data;
            _parent = null;
            _children = new();
        }

        public void AddChild(Node child)
        {
            _children.AddLast(child);
            child._parent = this;
        }
    }

    private static Node[] _nodes = null!;
    private static bool[] _bound = null!;
    
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [3, 333'333]
        int exN = n + 1;

        _nodes = new Node[exN];
        for (int i = 1; i < _nodes.Length; ++i)
        {
            _nodes[i] = new(i);
        }
        _bound = new bool[exN];

        while (true)
        {
            string? s = Console.ReadLine();
            if (string.IsNullOrEmpty(s))
                break;

            int[] tokens = Array.ConvertAll(s.Split(), int.Parse);
            int u = tokens[0];
            int v = tokens[1];

            _nodes[u].AddChild(_nodes[v]);
        }


    }

    private static void Solve()
    {
        
    }

    private static void SolveImplementation(Node parent)
    {
        for (var childLLN = parent.Children.First; childLLN != null; childLLN = childLLN.Next)
        {
            SolveImplementation(childLLN.Value);
        }


    }

    //private static bool Bindable(Node node)
    //{
    //    if (_bound[node.Data])
    //        return false;
    //}
    
    // case 1
    // * <- here
    // |
    // *
    // |
    // *
    //private static bool Case1(Node grandParent)
    //{
    //    
    //}
}