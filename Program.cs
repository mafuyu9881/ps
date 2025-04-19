using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 2'000]
        int m = tokens[1]; // [1, 2'100'000]

        LinkedList<int>[] adjList = new LinkedList<int>[n + 1];
        {
            for (int i = 1; i < adjList.Length; ++i)
            {
                adjList[i] = new();
            }
            for (int i = 0; i < m; ++i)
            {
                tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                int u = tokens[0]; // [1, n] = [1, 2'000]
                int v = tokens[1]; // [1, n] = [1, 2'000]
                adjList[u].AddLast(v);
                adjList[v].AddLast(u);
            }
        }

        bool[] receivedRuins = new bool[n + 1];
        {
            Console.ReadLine();
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int i = 0; i < tokens.Length; ++i)
            {
                receivedRuins[tokens[i]] = true;
            }
        }

        LinkedList<int> impactPoints = new();
        {
            bool[] simulatedRuins = new bool[n + 1];
            for (int v = 1; v <= n; ++v)
            {
                if (receivedRuins[v] == false)
                    continue;

                bool impactable = true;
                {
                    var adjs = adjList[v];
                    for (var lln = adjs.First; lln != null; lln = lln.Next)
                    {
                        int adjV = lln.Value;
                        if (receivedRuins[adjV] == false)
                        {
                            impactable = false;
                            break;
                        }
                    }
                }

                if (impactable)
                {
                    var adjs = adjList[v];
                    for (var lln = adjs.First; lln != null; lln = lln.Next)
                    {
                        int adjV = lln.Value;
                        simulatedRuins[adjV] = true;
                    }
                    simulatedRuins[v] = true;

                    impactPoints.AddLast(v);
                }
            }

            for (int i = 1; i <= n; ++i)
            {
                if (receivedRuins[i] != simulatedRuins[i])
                {
                    impactPoints = null!;
                    break;
                }
            }
        }

        StringBuilder sb = new();
        if (impactPoints == null)
        {
            sb.Append(-1);
        }
        else
        {
            sb.AppendLine($"{impactPoints.Count}");
            for (var lln = impactPoints.First; lln != null; lln = lln.Next)
            {
                sb.Append($"{lln.Value} ");
            }
        }
        Console.Write(sb);
    }
}