using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [2, 100]

        int height = n * 2 - 1;
        int width = n * 2 + (n - 2) * 2 + 1;

        StringBuilder sb = new();
        for (int row = 0; row < height; ++row)
        {
            for (int col = 0; col < width; ++col)
            {
                int leftBeginCol = (n - 1) - Math.Abs((n - 1) - row);
                int leftEndCol = leftBeginCol + (n - 1);

                int rightBeginCol = (width - 1) - leftBeginCol - (n - 1);
                int rightEndCol = rightBeginCol + (n - 1);

                if ((col >= leftBeginCol && col <= leftEndCol) ||
                    (col >= rightBeginCol && col <= rightEndCol))
                {
                    if (row == 0 || row == height - 1 ||
                        col == leftBeginCol || col == leftEndCol ||
                        col == rightBeginCol || col == rightEndCol)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                else if (col <= rightEndCol)
                {
                    sb.Append(' ');
                }
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}