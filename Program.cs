// 시간 제한: 1초
// 메모리 제한: 128MB
// 1 <= (컴퓨터의 수) <= 100

internal class Program
{
    private static void Main(string[] args)
    {
        int tno_computers = int.Parse(Console.ReadLine()!);

        int connections = int.Parse(Console.ReadLine()!);

        graph graph = new();
        for (int i = 0; i < connections; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();

            graph.connect(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }

        int connected_nodes_count = graph.compute_connected_nodes_count_by_bfs(1);

        Console.Write(connected_nodes_count);
    }
}

public class graph
{
    class node
    {
        private int data;
        public int Data { get { return data; } }
        private LinkedList<node> adjacencies = new();

        public node(int data)
        {
            this.data = data;
        }
        
        public bool equals(node? other)
        {
            if (other == null)
                return false;

            return equals(other.Data);
        }
        public bool equals(int other)
        {
            return data == other;
        }

        public void add_unique_adjacency(node adjacency)
        {
            if (adjacency == null)
                return;

            for (var node = adjacencies.First; node != null; node = node.Next)
                if (adjacency.equals(node.Value))
                    return;

            adjacencies.AddLast(adjacency);
            adjacency.adjacencies.AddLast(this);
        }

        public void for_each_adjacencies(Action<node> predicate)
        {
            for (var node = adjacencies.First; node != null; node = node.Next)
                predicate(node.Value);
        }
    }
    
    private LinkedList<node> nodes = new();
    
    private LinkedListNode<node>? find(int data)
    {
        for (var node = nodes.First; node != null; node = node.Next)
            if (node.Value.equals(data))
                return node;
                
        return null;
    }

    private LinkedListNode<node>? find_or_add(int data)
    {
        LinkedListNode<node>? output = find(data);
        if (output == null)
            output = nodes.AddLast(new node(data));

        return output;
    }

    public void connect(int data0, int data1)
    {
        LinkedListNode<node>? node0 = find_or_add(data0);
        LinkedListNode<node>? node1 = find_or_add(data1);

        node0!.ValueRef.add_unique_adjacency(node1!.ValueRef);
    }

    public int compute_connected_nodes_count_by_bfs(int initial_data)
    {
        int output = 0;

        var initial_node = find(initial_data);
        if (initial_node != null)
        {
            HashSet<int> visited = new();
            Queue<node> search_queue = new();
            search_queue.Enqueue(initial_node.ValueRef);

            while (search_queue.Count > 0)
            {
                node node = search_queue.Dequeue();
                node.for_each_adjacencies((adjacent_node) =>
                {
                    int adjacent_node_data = adjacent_node.Data;

                    if (visited.Contains(adjacent_node_data))
                        return;

                    search_queue.Enqueue(adjacent_node);
                    visited.Add(adjacent_node_data);
                    ++output;
                });
            }

            // initial_data에 해당하는 노드는 제외합니다.
            output -= 1;
        }

        return output;
    }
}