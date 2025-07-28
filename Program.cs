class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 200'000]

        // length = n
        // element = [1, 1'000'000'000]
        int[] stockPrices = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int maxProfit = 0;
        int minStockPrice = 1000000000;
        for (int i = 0; i < n; ++i)
        {
            int stockPrice = stockPrices[i];
            minStockPrice = Math.Min(minStockPrice, stockPrice);
            maxProfit = Math.Max(maxProfit, Math.Max(0, stockPrice - minStockPrice));
        }
        Console.Write(maxProfit);
    }
}