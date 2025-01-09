using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Tree tree = new();

        string? token;
        while ((token = Console.ReadLine()) != null)
        {
            tree.Add(int.Parse(token));
        }

        StringBuilder output = new();
        tree.PostOrderTraversal(output);
        Console.Write(output);
    }
    
    private class Tree
    {
        public class Node
        {
            private int _data;
            public int Data => _data;

            private Node? _parent;
            public Node? Parent => _parent;
            private Node? _leftChild;
            public Node? LeftChild => _leftChild;
            private Node? _rightChild;
            public Node? RightChild => _rightChild;

            public Node(int data)
            {
                _data = data;
                _parent = null;
                _leftChild = null;
                _rightChild = null;
            }
            
            public void AttachToLeftChild(Node leftChild)
            {
                _leftChild = leftChild;
                _leftChild._parent = this;
            }

            public void AttachToRightChild(Node rightChild)
            {
                _rightChild = rightChild;
                _rightChild._parent = this;
            }
        }

        private Node? _root;

        public Tree()
        {
            _root = null;
        }

        public void Add(int data)
        {
            Node node = new(data);

            if (_root == null)
            {
                _root = node;
            }
            else
            {
                Node? parent = _root;
                while (parent != null)
                {
                    if (data > parent.Data)
                    {
                        if (parent.RightChild == null)
                        {
                            parent.AttachToRightChild(node);
                            parent = null;
                        }
                        else
                        {
                            parent = parent.RightChild;
                        }
                    }
                    else // if (data < parent.Data) there are no nodes that have the same key
                    {
                        if (parent.LeftChild == null)
                        {
                            parent.AttachToLeftChild(node);
                            parent = null;
                        }
                        else
                        {
                            parent = parent.LeftChild;
                        }
                    }
                }
            }
        }

        public void PostOrderTraversal(StringBuilder output)
        {
            PostOrderTraversal(output, _root!);
        }

        private void PostOrderTraversal(StringBuilder output, Node currNode)
        {
            if (currNode.LeftChild != null)
            {
                PostOrderTraversal(output, currNode.LeftChild);
            }

            if (currNode.RightChild != null)
            {
                PostOrderTraversal(output, currNode.RightChild);
            }
            
            output.AppendLine($"{currNode.Data}");
        }
    }
}