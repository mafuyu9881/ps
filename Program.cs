internal class Program
{
    // 다익스트라 알고리즘은 간선이 연결되지 않았을 경우,
    // 간선의 거리를 무한으로 표현함으로써 일관된 계산식을 적용할 수 있도록 합니다.
    // 그러나 정수 연산에서 무한을 표현할 방법은 없기에
    // 실제 구현에선 임의의 매우 큰 값, 혹은 자료형의 최댓값
    // 또는 입력될 수 있는 데이터의 최댓값보다 큰 값을 무한으로 정의하고 사용합니다.
    // 하지만 이 구현에선, 음수를 무한으로 지정함으로써 코드의 범용성을 보장합니다.
    // 다익스트라 알고리즘에선 간선이 음수인 경우를 배제하므로 안심하고 사용할 수 있습니다.
    private const int Infinity = -1;
    private const int InvalidIndex = -1;
    // 노드의 개수입니다.
    private static int cities;
    // 노드 간의 간선을 인접 행렬로 표현한 것입니다.
    private static int[,] adjacencyMatrix;
    // 정해진 노드를 기준으로 계산된 최단 거리(최소 비용)입니다.
    private static int[] minimumCosts;
    // 노드들의 최단 거리 계산을 완료 여부입니다.
    private static bool[] completelyComputedCities;

    private static void Main(string[] args)
    {
        cities = int.Parse(Console.ReadLine()!);

        int buses = int.Parse(Console.ReadLine()!);

        adjacencyMatrix = new int[cities, cities];
        minimumCosts = new int[cities];
        completelyComputedCities = new bool[cities];

        int[] tokens;

        for (int i = 0; i < cities; ++i)
        {
            for (int j = 0; j < cities; ++j)
            {
                adjacencyMatrix[i, j] = (i == j) ? 0 : Infinity;
            }
        }

        for (int i = 0; i < buses; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int srcCityIndex = tokens[0] - 1;
            int dstCityIndex = tokens[1] - 1;
            int cost = tokens[2];

            adjacencyMatrix[srcCityIndex, dstCityIndex] = cost;
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int answerSrcCityIndex = tokens[0] - 1;
        int answerDstCityIndex = tokens[1] - 1;

        // 최단 경로 계산에 기준이 될 노드를 기반으로 초기값을 설정합니다.
        for (int i = 0; i < cities; ++i)
        {
            minimumCosts[i] = adjacencyMatrix[answerSrcCityIndex, i];
        }

        // 스스로에 대한 최단 거리는 이미 계산을 마친 상태나 다름 없습니다.
        completelyComputedCities[answerSrcCityIndex] = true;

        // 노드가 둘 이하일 경우엔 초기값이 곧 최단 거리입니다.
        for (int i = 0; i < cities - 2; ++i)
        {
            int cityIndex = GetNearestComputableCityIndex();

            // answerSrcCityIndex --(비용 A)--> cityIndex 직행 경로보다
            // 비용이 적게 드는 경로는 존재하지 않기 때문에,
            // 가장 가까운 도시는 이미 최단 거리 계산이 완료된 것으로 볼 수 있습니다.
            // 직행 경로 외의 경로라면 다른 노드를 경유하는 경로가 될 텐데,
            // 다음과 같이 약도를 표현할 수 있습니다.
            // answerSrcCityIndex --(비용 B)--> anotherCityIndex --(비용 C)--> cityIndex
            // 이 때, (비용 B) >= (비용 A)이므로 (비용 C)가 충분한 음수가 아닌 이상
            // (비용 B) + (비용 C) <= (비용 A)는 성립할 수 없습니다.
            // 그러나 다익스트라 알고리즘에선 모든 간선은 양수로 표현된다는 전제가 주어지기 때문에,
            // 이는 성립하지 않습니다.
            // 따라서 answerSrcCityIndex에서 가장 가까운 거리에 있는 도시는
            // 이미 최단 거리 계산이 완료된 것으로 이해할 수 있습니다.
            completelyComputedCities[cityIndex] = true;

            for (int j = 0; j < cities; ++j)
            {
                // cityIndex == j 조건도 내포하고 있습니다.
                if (completelyComputedCities[j])
                    continue;

                int costAnswerSrcCityIndexToCityIndex = minimumCosts[cityIndex];
                int costCityIndexToJ = adjacencyMatrix[cityIndex, j];
                if (costAnswerSrcCityIndexToCityIndex == Infinity ||
                    costCityIndexToJ == Infinity)
                    continue;
                int newCost = costAnswerSrcCityIndexToCityIndex + costCityIndexToJ;
                if (newCost < minimumCosts[j])
                {
                    minimumCosts[j] = newCost;
                }
            }
        }

        Console.Write(minimumCosts[answerDstCityIndex]);
    }

    // shortestDistances, computedCities 필드에 의존하는 함수입니다.
    private static int GetNearestComputableCityIndex()
    {
        int nearestIndex = InvalidIndex;
        for (int i = 0; i < cities; ++i)
        {
            if (completelyComputedCities[i])
                continue;

            if (minimumCosts[i] == Infinity)
                continue;

            if (nearestIndex == InvalidIndex ||
                minimumCosts[i] < minimumCosts[nearestIndex])
            {
                nearestIndex = i;
            }
        }
        return nearestIndex;
    }
}