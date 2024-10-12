internal class Program
{
    private struct ConnectionData
    {
        public int connectedIndex;
        public int cost;

        public ConnectionData(int connectedIndex, int cost)
        {
            this.connectedIndex = connectedIndex;
            this.cost = cost;
        }
    }

    private class ConnectionDataComparer : IComparer<ConnectionData>
    {
        public int Compare(ConnectionData x, ConnectionData y)
        {
            if (x.cost == y.cost)
            {
                return 0;
            }
            else if (x.cost < y.cost)
            {
                return -1;
            }
            else // if (x.cost > y.cost)
            {
                return 1;
            }
        }
    }

    private static void Main(string[] args)
    {
        const int Infinity = -1;

        int cities = int.Parse(Console.ReadLine()!);

        int buses = int.Parse(Console.ReadLine()!);

        LinkedList<ConnectionData>[] adjacencyList = new LinkedList<ConnectionData>[cities];

        int[] tokens;

        for (int i = 0; i < buses; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int srcCityIndex = tokens[0] - 1;
            int dstCityIndex = tokens[1] - 1;
            int cost = tokens[2];

            if (adjacencyList[srcCityIndex] == null)
                adjacencyList[srcCityIndex] = new();

            if (adjacencyList[dstCityIndex] == null)
                adjacencyList[dstCityIndex] = new();

            adjacencyList[srcCityIndex].AddLast(new ConnectionData(dstCityIndex, cost));
            // 이 문제는 단방향 그래프입니다.
            //adjacencyList[dstCityIndex].AddLast(new ConnectionData(srcCityIndex, cost));
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int answerSrcCityIndex = tokens[0] - 1;
        int answerDstCityIndex = tokens[1] - 1;

        int[] minimumCosts = new int[cities];
        for (int i = 0; i < cities; ++i)
        {
            minimumCosts[i] = Infinity;
        }

        minimumCosts[answerSrcCityIndex] = 0;

        ConnectionDataComparer connectionDataComparer = new();

        ConnectionData answerSrcCitySelfConnectionData = new(answerSrcCityIndex, minimumCosts[answerSrcCityIndex]);

        bool[] computedCities = new bool[cities];

        PriorityQueue<ConnectionData, ConnectionData> computingQueue = new(connectionDataComparer);
        computingQueue.Enqueue(answerSrcCitySelfConnectionData, answerSrcCitySelfConnectionData);
        while (computingQueue.Count > 0)
        {
            // answerSrcCityIndex와 연결된 도시로의 연결 정보
            ConnectionData dstConnectionData = computingQueue.Dequeue();
            // answerSrcCityIndex와 연결된 도시
            int dstCityIndex = dstConnectionData.connectedIndex;
            // 간선의 비용
            int dstCost = dstConnectionData.cost;

            // 최단 경로가 아니라면 건너뜁니다.
            if (minimumCosts[dstCityIndex] != Infinity &&
                minimumCosts[dstCityIndex] < dstCost)
                continue;

            computedCities[dstCityIndex] = true;

            // 최단 경로 계산이 완료된 도시로의 연결은
            // 실제 그래프 상에선 아래와 같이 간접적으로 이루어진 모습이더라도
            // answerSrcCityIndex --(cost A)--> anotherCityIndex --(cost B)--> dstCityIndex
            // (dstCost) = (cost A) + (cost B)
            // 다음과 같이 직접 연결된 것으로 표현할 수 있습니다.
            // answerSrcCityIndex --(dstCost)--> dstCityIndex
            // 이것이 다익스트라 알고리즘의 이해와 실제 구현으로
            // 옮기는 데에 필요한 최중요 아이디어입니다.

            // dstCityIndex와 연결된 도시들로의 연결 정보
            var dstAdjacentConnectionDataList = adjacencyList[dstCityIndex];
            for (var node = dstAdjacentConnectionDataList.First; node != null; node = node.Next)
            {
                // dstCityIndex와 연결된 도시로의 연결 정보
                ConnectionData dstAdjacentConnectionData = node.Value;
                // dstCityIndex와 연결된 도시
                int dstAdjacentCityIndex = dstAdjacentConnectionData.connectedIndex;
                // 간선의 비용
                int dstAdjacentCost = dstAdjacentConnectionData.cost;

                // 최단 거리 계산이 완료된 도시는 건너뜁니다.
                if (computedCities[dstAdjacentCityIndex])
                    continue;

                // answerSrcCityIndex에서 dstAdjacentCityIndex로의 간선의 비용
                int newCost = dstCost + dstAdjacentCost;
                if (minimumCosts[dstAdjacentCityIndex] == Infinity ||
                    newCost < minimumCosts[dstAdjacentCityIndex])
                {
                    minimumCosts[dstAdjacentCityIndex] = newCost;

                    ConnectionData answerSrcCityIndexToDstAdjacentCityIndexConnectionData = new(dstAdjacentCityIndex, newCost);
                    computingQueue.Enqueue(answerSrcCityIndexToDstAdjacentCityIndexConnectionData,
                                           answerSrcCityIndexToDstAdjacentCityIndexConnectionData);
                }
            }
        }
        
        Console.Write(minimumCosts[answerDstCityIndex]);
    }
}