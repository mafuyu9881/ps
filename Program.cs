using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int InvalidData = -1;
        
        int n = int.Parse(Console.ReadLine()!);

        Graph graph = new();
        for (int i = 0; i < n; ++i)
        {
            char[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), char.Parse);
            
            int parent = tokens[0] - 'A';
            int leftChild = tokens[1] - 'A';
            int rightChild = tokens[2] - 'A';

            if (parent > InvalidData)
            {
                if (leftChild > InvalidData)
                {
                    graph.AddLeft(parent, leftChild);
                }

                if (rightChild > InvalidData)
                {
                    graph.AddRight(parent, rightChild);
                }
            }
        }

        StringBuilder output = new();
        output.AppendLine($"{graph.Order(Graph.TraversalMethod.Preorder)}");
        output.AppendLine($"{graph.Order(Graph.TraversalMethod.Inorder)}");
        output.AppendLine($"{graph.Order(Graph.TraversalMethod.Postorder)}");
        Console.Write(output);
    }

    private class Graph
    {
        public enum TraversalMethod
        {
            Preorder,
            Inorder,
            Postorder,
        }

        private struct Node
        {
            private int? _leftChild = null;
            public int? LeftChild
            {
                get { return _leftChild; }
                set { _leftChild = value; }
            }
            private int? _rightChild = null;
            public int? RightChild
            {
                get { return _rightChild; }
                set { _rightChild = value; }
            }

            public Node()
            {

            }
        }

        Node[] nodes;

        public Graph()
        {
            nodes = new Node['Z' - 'A' + 1];
        }

        public void AddLeft(int parent, int child)
        {
            nodes[parent].LeftChild = child;
        }

        public void AddRight(int parent, int child)
        {
            nodes[parent].RightChild = child;
        }

        public StringBuilder Order(TraversalMethod traversalMethod)
        {
            StringBuilder output = new();
            OrderImplementation(output, 0, traversalMethod);
            return output;
        }

        private void OrderImplementation(StringBuilder output,
                                         int parent,
                                         TraversalMethod traversalMethod)
        {
            var parentNode = nodes[parent];
            var leftChildNode = parentNode.LeftChild;
            var rightChildNode = parentNode.RightChild;

            Action print = () =>
            {
                output.Append((char)(parent + 'A'));
            };

            if (traversalMethod == TraversalMethod.Preorder)
                print();

            if (leftChildNode.HasValue)
                OrderImplementation(output, leftChildNode.Value, traversalMethod);

            if (traversalMethod == TraversalMethod.Inorder)
                print();

            if (rightChildNode.HasValue)
                OrderImplementation(output, rightChildNode.Value, traversalMethod);

            if (traversalMethod == TraversalMethod.Postorder)
                print();
        }
    }
}