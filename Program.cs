internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int width = tokens[0]; // [?, 100]
        int height = tokens[1]; // [?, 100]

        int cuts = int.Parse(Console.ReadLine()!);
        LinkedList<int> horizontalCuttingPointLL = new();
        LinkedList<int> verticalCuttingPointLL = new();
        for (int i = 0; i < cuts; ++i) // max tc = 99 + 99 = 198
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            LinkedList<int> cuttingPointLL = null!;
            if (tokens[0] == 0)
            {
                cuttingPointLL = horizontalCuttingPointLL;
            }
            else
            {
                cuttingPointLL = verticalCuttingPointLL;
            }
            cuttingPointLL.AddLast(tokens[1]);
        }
        horizontalCuttingPointLL.AddFirst(0);
        horizontalCuttingPointLL.AddLast(height);
        verticalCuttingPointLL.AddFirst(0);
        verticalCuttingPointLL.AddLast(width);

        int[] horizontalCuttingPointArr = horizontalCuttingPointLL.ToArray(); // max tc = 101
        int[] verticalCuttingPointArr = verticalCuttingPointLL.ToArray(); // max tc = 101
        Array.Sort(horizontalCuttingPointArr);
        Array.Sort(verticalCuttingPointArr);

        int[] horizontalLengthArr = CuttingPointsToLengths(horizontalCuttingPointArr); // max tc = 100
        int[] verticalLengthArr = CuttingPointsToLengths(verticalCuttingPointArr); // max tc = 100

        int output = 0;
        for (int i = 0; i < horizontalLengthArr.Length; ++i) // max tc = 100
        {
            for (int j = 0; j < verticalLengthArr.Length; ++j) // max tc = 100
            {
                output = Math.Max(output, horizontalLengthArr[i] * verticalLengthArr[j]);
            }
        }
        Console.Write(output);
    }

    private static int[] CuttingPointsToLengths(int[] cuttingPoints) // tc = cuttingPoints.Length - 1
    {
        int cuttingPointsLength = cuttingPoints.Length;

        int[] lengths = new int[cuttingPointsLength - 1];
        for (int i = 0; i < cuttingPointsLength - 1; ++i)
        {
            lengths[i] = cuttingPoints[i + 1] - cuttingPoints[i];
        }

        return lengths;
    }
}