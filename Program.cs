internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        PaintingCost[] accPaintingCosts = new PaintingCost[n + 1];
        accPaintingCosts[0].r = 0;
        accPaintingCosts[0].g = 0;
        accPaintingCosts[0].b = 0;
        for (int i = 1; i <= n; ++i)
        {
            string[] tokens = Console.ReadLine()!.Split();

            PaintingCost prevAccPaintingCost = accPaintingCosts[i - 1];
            
            PaintingCost currPaintingCost;
            currPaintingCost.r = Math.Min(prevAccPaintingCost.g, prevAccPaintingCost.b) + int.Parse(tokens[0]);
            currPaintingCost.g = Math.Min(prevAccPaintingCost.r, prevAccPaintingCost.b) + int.Parse(tokens[1]);
            currPaintingCost.b = Math.Min(prevAccPaintingCost.r, prevAccPaintingCost.g) + int.Parse(tokens[2]);

            accPaintingCosts[i] = currPaintingCost;
        }
        Console.Write(Math.Min(accPaintingCosts[n].r, Math.Min(accPaintingCosts[n].g, accPaintingCosts[n].b)));
    }

    private struct PaintingCost
    {
        public int r;
        public int g;
        public int b;
    }
}