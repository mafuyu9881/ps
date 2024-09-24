internal class Program
{
    private static void Main(string[] args)
    {
        avl_tree tree = new();
        tree.insert(5);
        tree.insert(3);
        tree.insert(4);
        tree.insert(1);
        tree.insert(2);
        tree.inorder(true);
    }
}

public class avl_tree
{
    private class node
    {
        public int data;
        public node left = null!;
        public node right = null!;
        
        public node(int data)
        {
            this.data = data;
        }
    }
    
    private node root = null!;
    
    public void insert(int data)
    {
        node new_node = new(data);

        if (root != null)
        {
            insert(root, new_node);
        }
        else
        {
            root = new_node;
        }
    }

    public void inorder(bool print)
    {
        inorder_implementation(print, root);
    }
    private void inorder_implementation(bool print, node parent_node)
    {
        if (parent_node == null)
            return;

        node left_child_node = parent_node.left;
        if (left_child_node != null)
        {
            inorder_implementation(print, left_child_node);
        }

        if (print)
        {
            Console.WriteLine(parent_node.data);
        }

        node right_child_node = parent_node.right;
        if (right_child_node != null)
        {
            inorder_implementation(print, right_child_node);
        }
    }

    private void insert(node parent_node, node new_node)
    {
        //if (parent_node == null)
        //    return;

        int new_node_data = new_node.data;
        int parent_data = parent_node.data;

        if (new_node_data < parent_data)
        {
            node child_node = parent_node.left;
            if (child_node != null)
            {
                insert(child_node, new_node);
            }
            else
            {
                parent_node.left = new_node;
                // TODO: set_height(..)
            }
        }
        else if (new_node_data > parent_data)
        {
            node child_node = parent_node.right;
            if (child_node != null)
            {
                insert(child_node, new_node);
            }
            else
            {
                parent_node.right = new_node;
                // TODO: set_height(..)
            }
        }
        else
        {
            // 같은 값은 저장하지 않습니다.
            // TODO: 삽입을 시도하기 이전에 탐색을 통해 핸들해야 합니다.
            return;
        }
    }
}