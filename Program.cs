internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[,] housePaintingCosts = new int[n, 3];
        for (int i = 0; i < n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();

            housePaintingCosts[i, 0] = int.Parse(tokens[0]);
            housePaintingCosts[i, 1] = int.Parse(tokens[1]);
            housePaintingCosts[i, 2] = int.Parse(tokens[2]);
        }

        int? minPaintingCosts = null;
        ComputeMinPaintingCosts(ref minPaintingCosts,
                                housePaintingCosts,
                                0,
                                -1,
                                -1,
                                n);
        Console.Write(minPaintingCosts);
    }

    private static void ComputeMinPaintingCosts(ref int? minPaintingCosts,
                                               int[,] housePaintingCosts,
                                               int prevAccPaintingCosts,
                                               int prevHouseIndex,
                                               int prevColorIndex,
                                               int n)
    {
        int currHouseIndex = prevHouseIndex + 1;
        
        for (int i = 0; i < 3; ++i)
        {
            if (i == prevColorIndex)
                continue;
            
            int paintingCost = housePaintingCosts[currHouseIndex, i];

            int currAccPaintingCosts = prevAccPaintingCosts + paintingCost;

            if (minPaintingCosts.HasValue == false ||
                currAccPaintingCosts < minPaintingCosts)
            {
                if (currHouseIndex < (n - 1))
                {
                    ComputeMinPaintingCosts(ref minPaintingCosts,
                                            housePaintingCosts,
                                            currAccPaintingCosts,
                                            currHouseIndex,
                                            i,
                                            n);
                }
                else
                {
                    minPaintingCosts = currAccPaintingCosts;
                }
            }
        }
    }
}