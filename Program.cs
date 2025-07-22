using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int height = tokens[0]; // [2, 100]
        int width = tokens[1]; // [2, 100]
        int r = tokens[2]; // [1, 1'000]

        int side = Math.Max(height, width);

        int[,] frontBuffer = new int[side, side];
        int[,] backBuffer = new int[side, side];
        for (int row = 0; row < height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < width; ++col)
            {
                frontBuffer[row, col] = tokens[col];
            }
        }

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        for (int i = 0; i < r; ++i) // max tc = 1'000
        {
            int command = tokens[i];

            if (command == 1)
            {
                for (int row = 0; row < height; ++row)
                {
                    for (int col = 0; col < width; ++col)
                    {
                        backBuffer[row, col] = frontBuffer[height - 1 - row, col];
                    }
                }
            }
            else if (command == 2)
            {
                for (int row = 0; row < height; ++row)
                {
                    for (int col = 0; col < width; ++col)
                    {
                        backBuffer[row, col] = frontBuffer[row, width - 1 - col];
                    }
                }
            }
            else if (command == 3)
            {
                for (int row = 0; row < height; ++row)
                {
                    for (int col = 0; col < width; ++col)
                    {
                        backBuffer[col, height - 1 - row] = frontBuffer[row, col];
                        int temp = height;
                        height = width;
                        width = temp;
                    }
                }
            }
            else if (command == 4)
            {
                for (int row = 0; row < height; ++row)
                {
                    for (int col = 0; col < width; ++col)
                    {
                        backBuffer[width - 1 - col, row] = frontBuffer[row, col];
                        int temp = height;
                        height = width;
                        width = temp;
                    }
                }
            }
            else
            {
                int halfHeight = height / 2;
                int halfWidth = width / 2;

                for (int row = 0; row < height; ++row)
                {
                    for (int col = 0; col < width; ++col)
                    {
                        int oldY = row / halfHeight;
                        int oldX = col / halfWidth;

                        int newY;
                        int newX;

                        if (command == 5)
                        {
                            if (oldY == 0 && oldX == 0)
                            {
                                newY = 0;
                                newX = 1;
                            }
                            else if (oldY == 0 && oldX == 1)
                            {
                                newY = 1;
                                newX = 1;
                            }
                            else if (oldY == 1 && oldX == 1)
                            {
                                newY = 1;
                                newX = 0;
                            }
                            else
                            {
                                newY = 0;
                                newX = 0;
                            }
                        }
                        else // if (command == 6)
                        {
                            if (oldY == 0 && oldX == 0)
                            {
                                newY = 1;
                                newX = 0;
                            }
                            else if (oldY == 0 && oldX == 1)
                            {
                                newY = 0;
                                newX = 0;
                            }
                            else if (oldY == 1 && oldX == 1)
                            {
                                newY = 0;
                                newX = 1;
                            }
                            else
                            {
                                newY = 1;
                                newX = 1;
                            }
                        }

                        backBuffer[newY * halfHeight + row % halfHeight, newX * halfWidth + col % halfWidth] = frontBuffer[row, col];
                    }
                }
            }

            {
                int[,] temp = frontBuffer;
                frontBuffer = backBuffer;
                backBuffer = temp;
            }
        }

        StringBuilder sb = new();
        for (int row = 0; row < height; ++row)
        {
            for (int col = 0; col < width; ++col)
            {
                sb.Append($"{frontBuffer[row, col]} ");
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}