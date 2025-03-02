using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // element = [1, 200]
        int[] integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int planeHeight = integerTokens[0];
        int planeWidth = integerTokens[1];

        // element = [1, 200]
        integerTokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int textureHeight = integerTokens[0];
        int textureWidth = integerTokens[1];

        char[,] texture = new char[textureHeight, textureWidth];
        for (int row = 0; row < textureHeight; ++row) // max tc = 200
        {
            string stringToken = Console.ReadLine()!;
            for (int col = 0; col < textureWidth; ++col) // max tc = 200
            {
                texture[row, col] = stringToken[col];
            }
        }
        
        string method = Console.ReadLine()!;
        if (method == "clamp-to-edge")
        {
            Console.Write(ClampToEdge(planeHeight, planeWidth, textureHeight, textureWidth, texture));
        }
        else if (method == "repeat")
        {
            Console.Write(Repeat(planeHeight, planeWidth, textureHeight, textureWidth, texture));
        }
        else // if (method == "mirrored-repeat")
        {
            Console.Write(MirroredRepeat(planeHeight, planeWidth, textureHeight, textureWidth, texture));
        }
    }

    private static StringBuilder ClampToEdge(int planeHeight, int planeWidth, int textureHeight, int textureWidth, char[,] texture)
    {
        StringBuilder sb = new();

        for (int row = 0; row < planeHeight; ++row) // max tc = 200
        {
            for (int col = 0; col < planeWidth; ++col) // max tc = 200
            {
                sb.Append($"{texture[Math.Min(textureHeight - 1, row), Math.Min(textureWidth - 1, col)]}");
            }
            sb.AppendLine();
        }

        return sb;
    }

    private static StringBuilder Repeat(int planeHeight, int planeWidth, int textureHeight, int textureWidth, char[,] texture)
    {
        StringBuilder sb = new();

        for (int row = 0; row < planeHeight; ++row) // max tc = 200
        {
            for (int col = 0; col < planeWidth; ++col) // max tc = 200
            {
                sb.Append($"{texture[row % textureHeight, col % textureWidth]}");
            }
            sb.AppendLine();
        }

        return sb;
    }

    private static StringBuilder MirroredRepeat(int planeHeight, int planeWidth, int textureHeight, int textureWidth, char[,] texture)
    {
        StringBuilder sb = new();

        for (int row = 0; row < planeHeight; ++row) // max tc = 200
        {
            for (int col = 0; col < planeWidth; ++col) // max tc = 200
            {
                sb.Append($"{texture[ComputeMirroredIndex(row, textureHeight), ComputeMirroredIndex(col, textureWidth)]}");
            }
            sb.AppendLine();
        }
        
        return sb;
    }

    private static int ComputeMirroredIndex(int index, int length)
    {
        int texIndex = index % length;

        if (((index / length) % 2) != 0)
        {
            texIndex = length - 1 - texIndex;
        }

        return texIndex;
    }
}