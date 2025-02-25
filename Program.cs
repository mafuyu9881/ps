using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // element = [0, 100'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int k = tokens[1];

        const int InvalidCost = -1;
        (int cost, int visits)[] histories = new (int, int)[100001];
        for (int i = 0; i < histories.Length; ++i)
        {
            histories[i] = (InvalidCost, 0);
        }

        Queue<int> frontier = new();

        histories[n] = (0, 1);
        frontier.Enqueue(n);

        while (frontier.Count > 0)
        {
            int index = frontier.Dequeue();

            var history = histories[index];
            int cost = history.cost;

            int[] adjIndices = new int[]
            {
                index - 1,
                index + 1,
                index * 2,
            };

            for (int i = 0; i < adjIndices.Length; ++i)
            {
                int adjIndex = adjIndices[i];
                if (adjIndex < 0)
                    continue;

                if (adjIndex > histories.Length - 1)
                    continue;

                int newCost = cost + 1;
                if (adjIndex > k &&
                    histories[k].cost != InvalidCost &&
                    newCost + adjIndex - k > histories[k].cost)
                    continue;

                int oldCost = histories[adjIndex].cost;
                if (oldCost != InvalidCost && oldCost < newCost)
                    continue;

                if (oldCost == newCost)
                {
                    ++histories[adjIndex].visits;
                }
                else
                {
                    histories[adjIndex] = (newCost, 1);
                }

                frontier.Enqueue(adjIndex);
            }
        }
        
        StringBuilder sb = new();
        sb.AppendLine($"{histories[k].cost}");
        sb.AppendLine($"{histories[k].visits}");
        Console.Write(sb);
    }
}