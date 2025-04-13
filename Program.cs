internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // length = 3
        int width = tokens[0] + 1; // [1 + 1, 50 + 1]
        int height = tokens[1] + 1; // [1 + 1, 50 + 1]
        int objective = tokens[2]; // [2, 50]

        int end = width * height;

        int segments = 0;
        for (int i0 = 0; i0 < end; ++i0) // max tc = 51 * 51 = 2'601
        {
            for (int i1 = i0 + 1; i1 < end; ++i1) // max tc = 2'601
            {
                int x0 = i0 % width;
                int y0 = i0 / width;

                int x1 = i1 % width;
                int y1 = i1 / width;

                int xStride = x1 - x0;
                int yStride = y1 - y0;

                int strideGCD = GCD(Math.Abs(xStride), Math.Abs(yStride));

                xStride /= strideGCD;
                yStride /= strideGCD;

                int i = 0;
                while (true) // max tc = 50
                {
                    if (i > objective)
                        break;

                    int x = x0 + xStride * i;
                    if (x < 0 || x > width - 1)
                        break;

                    if (xStride < 0 && x < x1)
                        break;

                    if (xStride > 0 && x > x1)
                        break;

                    int y = y0 + yStride * i;
                    if (y < 0 || y > height - 1)
                        break;

                    if (yStride < 0 && y < y1)
                        break;

                    if (yStride > 0 && y > y1)
                        break;

                    ++i;
                }

                if (i == objective)
                    ++segments;
            }
        }
        Console.Write(segments);
    }

    private static int GCD(int a, int b)
    {
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);

        while (min > 0)
        {
            int temp = max % min;
            max = min;
            min = temp;
        }

        return max;
    }
}