// 시간 제한: 3초
// 메모리 제한: 512MB
// 1 ≤ N ≤ 1,000
// 0 ≤ M ≤ N(N-1)/2

internal class Program
{
    private static void Main(string[] args)
    {
        string[] tokens = Console.ReadLine()!.Split();

        int n = int.Parse(tokens[0]);
        int m = int.Parse(tokens[1]);

        Graph graph = new(n);
        for (int i = 0; i < m; ++i)
        {
            tokens = Console.ReadLine()!.Split();
            graph.Connect(int.Parse(tokens[0]), int.Parse(tokens[1]));
        }
        Console.Write(graph.ComputeConnectedComponentCount());
    }
}

public class Graph
{
    private LinkedList<int>[]? adjacencyList = null;

    public Graph(int nodeCount)
    {
        int adjacencyListLength = nodeCount + 1;

        adjacencyList = new LinkedList<int>[adjacencyListLength];
        for (int i = 0; i < adjacencyListLength; ++i)
        {
            adjacencyList[i] = new();
        }
    }

    public void Connect(int node0, int node1)
    {
        if (adjacencyList == null)
            return;

        int writableLength = adjacencyList.Length;
        if (node0 > writableLength || node1 > writableLength)
            return;
        
        // 중복된 간선에 대한 검사는 생략합니다.
        // 설령 중복된 간선이 들어오더라도, 그래프 순회에서 순회 횟수가 1회 늘어나는 것 말고는 문제될 일은 없습니다.
        adjacencyList[node0].AddLast(node1);
        adjacencyList[node1].AddLast(node0);
    }

    public int ComputeConnectedComponentCount()
    {
        LinkedList<LinkedList<int>> connectedComponents = new();

        if (adjacencyList == null)
            return connectedComponents.Count;

        // 적어도 0과 1은 노드로 들어와있어야 합니다.
        int adjacencyListLength = adjacencyList.Length;
        if (adjacencyListLength < 2)
            return connectedComponents.Count;

        bool[] visitedLookup = new bool[adjacencyListLength];
        Stack<int> visitingStack = new();
        
        LinkedList<int> objectiveList = new();
        for (int i = 1; i < adjacencyListLength; ++i)
        {
            objectiveList.AddLast(i);
        }

        while (objectiveList.Count > 0)
        {
            if (visitingStack.Count < 1)
            {
                var objectiveNode = objectiveList.First;
                if (objectiveNode == null)
                    break;

                visitingStack.Push(objectiveNode.Value);
                objectiveList.Remove(objectiveNode);
            }

            int visitingNode = visitingStack.Pop();

            LinkedList<int>? visitingConnectedComponent = null;
            if (visitedLookup[visitingNode] == false)
            {
                visitingConnectedComponent = new();
                visitingConnectedComponent.AddLast(visitingNode);
                connectedComponents.AddLast(visitingConnectedComponent);
            }
            else
            {
                for (var outerNode = connectedComponents.First; outerNode != null; outerNode = outerNode.Next)
                {
                    var connectedComponent = outerNode.Value;
                    if (connectedComponent.Contains(visitingNode))
                    {
                        visitingConnectedComponent = connectedComponent;
                        break;
                    }
                }
            }

            visitedLookup[visitingNode] = true;
            
            var adjacencies = adjacencyList[visitingNode];
            for (var node = adjacencies.First; node != null; node = node.Next)
            {
                int adjacentNode = node.Value;
                if (visitedLookup[adjacentNode])
                    continue;

                visitingConnectedComponent!.AddLast(adjacentNode);
                
                visitedLookup[adjacentNode] = true;
                visitingStack.Push(adjacentNode);
            }
        }

        return connectedComponents.Count;
    }
}