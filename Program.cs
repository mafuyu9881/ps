internal class Program
{
    private static void Main(string[] args)
    {
        // 1명 당 100원이 들고, 1,000명을 늘려야 할 때 드는 비용은 100,000 입니다.
        // 따라서 이 값을 초과하는 수는 무한을 표현하는 데에 사용하기 적합합니다.
        const int Infinity = 100001;

        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int c = tokens[0];
        int n = tokens[1];

        // 일관된 점화식으로 최솟값을 계산할 수 있도록, 0행의 원소를 무한으로 초기화합니다.
        // 홍보하는 도시의 수가 0 이면 아무리 더해도 1 이상의 고객을 모을 수 없습니다.
        int[,] dp = new int[n + 1, c + 1];
        for (int i = 1; i <= c; ++i)
        {
            dp[0, i] = Infinity;
        }
        
        for (int i = 1; i <= n; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            
            int cost = tokens[0];
            int customers = tokens[1];

            for (int j = 1; j <= c; ++j)
            {
                if (j <= customers)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], cost);
                }
                else
                {
                    dp[i, j] = dp[i - 1, j];
                    for (int promotionCount = 1; j - (customers * promotionCount) > 0; ++promotionCount)
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i, j - (customers * promotionCount)] + cost * promotionCount);
                    }
                }
            }
        }
        Console.Write(dp[n, c]);
    }
}