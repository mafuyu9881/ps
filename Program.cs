using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // length = 2
        // element = [1, 1'000]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0];
        int width = tokens[1];

        StringBuilder sb = new();
        if (height == 1 || width == 1)
        {
            sb.AppendLine($"{Math.Min(2, height * width)}");

            if (height == 1)
            {
                for (int col = 0; col < width; ++col)
                {
                    if (col % 2 == 0)
                    {
                        sb.Append("1 ");
                    }
                    else
                    {
                        sb.Append("2 ");
                    }
                }
            }
            else
            {
                for (int row = 0; row < height; ++row)
                {
                    if (row % 2 == 0)
                    {
                        sb.AppendLine("1 ");
                    }
                    else
                    {
                        sb.AppendLine("2 ");
                    }
                }
            }
        }
        else
        {
            sb.AppendLine($"{Math.Min(4, height * width)}");

            for (int row = 0; row < height; ++row) // max tc = 1'000
            {
                for (int col = 0; col < width; ++col) // max tc = 1'000
                {
                    if (row % 2 == 0)
                    {
                        if (col % 2 == 0)
                        {
                            sb.Append("1 ");
                        }
                        else
                        {
                            sb.Append("2 ");
                        }
                    }
                    else
                    {
                        if (col % 2 == 0)
                        {
                            sb.Append("3 ");
                        }
                        else
                        {
                            sb.Append("4 ");
                        }
                    }
                }
                sb.AppendLine();
            }
        }

        Console.Write(sb);
    }
}