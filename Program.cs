using System.Text;

internal class Program
{
    private enum Relationship
    {
        BothVertical,
        EitherVertical,
    }

    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 10]

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 10
        {
            // length = 8
            // element = [-1'000, 1'000]
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x1 = tokens[0];
            int y1 = tokens[1];
            int x2 = tokens[2];
            int y2 = tokens[3];
            int x3 = tokens[4];
            int y3 = tokens[5];
            int x4 = tokens[6];
            int y4 = tokens[7];

            var a1 = ComputeSlope(x1, y1, x2, y2);
            var a2 = ComputeSlope(x3, y3, x4, y4);

            if (a1.vertical && a2.vertical)
            {
                if (x1 == x3)
                {
                    sb.AppendLine("LINE");
                }
                else
                {
                    sb.AppendLine("NONE");
                }
            }
            else if (a1.vertical == false && a2.vertical == false && Math.Abs(a1.slope - a2.slope) < 0.01f)
            {
                float b1 = ComputeYIntercept(x1, y1, a1.slope);
                float b2 = ComputeYIntercept(x3, y3, a2.slope);

                if (Math.Abs(b1 - b2) < 0.01f)
                {
                    sb.AppendLine("LINE");
                }
                else
                {
                    sb.AppendLine("NONE");
                }
            }
            else
            {
                float x;
                float y;

                if (a1.vertical)
                {
                    float b2 = ComputeYIntercept(x3, y3, a2.slope);

                    x = x1;
                    y = a2.slope * x + b2;
                }
                else if (a2.vertical)
                {
                    float b1 = ComputeYIntercept(x1, y1, a1.slope);

                    x = x2;
                    y = a1.slope * x + b1;
                }
                else
                {
                    float b1 = ComputeYIntercept(x1, y1, a1.slope);
                    float b2 = ComputeYIntercept(x3, y3, a2.slope);

                    x = (b2 - b1) / (float)(a1.slope - a2.slope);
                    y = a1.slope * x + b1;
                }
                sb.AppendLine($"POINT {x.ToString("F2")} {y.ToString("F2")}");
            }
        }
        Console.Write(sb);
    }

    private static (bool vertical, float slope) ComputeSlope(int x1, int y1, int x2, int y2)
    {
        bool vertical = (x1 == x2);
        float slope = 0.0f;

        if (vertical == false)
        {
            slope = (y2 - y1) / (float)(x2 - x1);
        }

        return (vertical, slope);
    }

    private static float ComputeYIntercept(int x, int y, float slope)
    {
        return y - slope * x;
    }
}