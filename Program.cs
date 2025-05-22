using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int width = tokens[0]; // [3, 100'000]
        int walls = tokens[1]; // [0, N) = [0, 100'000)
        int students = tokens[2]; // [1, 100'000]

        int[] map = new int[width + 1];
        for (int i = 0; i < walls; ++i)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int pos = tokens[0]; // [1, N] = [1, 100'000]
            int durability = tokens[1]; // [1, 100'000]
            map[pos] = durability;
        }

        long[] mapPrefixSumsFromLeft = new long[width + 1];
        for (int i = 1; i <= width; ++i)
        {
            mapPrefixSumsFromLeft[i] = mapPrefixSumsFromLeft[i - 1] + map[i];
        }

        long[] mapPrefixSumsFromRight = new long[width + 1];
        mapPrefixSumsFromRight[width] = map[width];
        for (int i = width - 1; i > 0; --i)
        {
            mapPrefixSumsFromRight[i] = mapPrefixSumsFromRight[i + 1] + map[i];
        }

        const int InvalidBrokenPos = -1;
        int brokenPosFromLeft = InvalidBrokenPos;
        int brokenPosFromRight = InvalidBrokenPos;

        StringBuilder sb = new();
        for (int i = 0; i < students; ++i)
        {
            int pos = int.Parse(Console.ReadLine()!);

            long leftDurabilities = mapPrefixSumsFromLeft[pos - 1];
            if (brokenPosFromLeft != InvalidBrokenPos)
            {
                leftDurabilities = Math.Max(0, leftDurabilities - mapPrefixSumsFromLeft[brokenPosFromLeft]);
            }

            long rightDurabilities = mapPrefixSumsFromRight[pos + 1];
            if (brokenPosFromRight != InvalidBrokenPos)
            {
                rightDurabilities = Math.Max(0, rightDurabilities - mapPrefixSumsFromRight[brokenPosFromRight]);
            }

            bool escapeToLeftward;
            if (leftDurabilities < rightDurabilities)
            {
                escapeToLeftward = true;
            }
            else if (leftDurabilities > rightDurabilities)
            {
                escapeToLeftward = false;
            }
            else
            {
                int leftDistance = pos - 1;
                int rightDistance = width - pos;
                if (leftDistance <= rightDistance)
                {
                    escapeToLeftward = true;
                }
                else
                {
                    escapeToLeftward = false;
                }
            }

            if (escapeToLeftward)
            {
                sb.AppendLine($"{leftDurabilities}");
                if (brokenPosFromLeft == InvalidBrokenPos ||
                    pos > brokenPosFromLeft)
                {
                    brokenPosFromLeft = pos;
                }
            }
            else
            {
                sb.AppendLine($"{rightDurabilities}");
                if (brokenPosFromRight == InvalidBrokenPos ||
                    pos < brokenPosFromRight)
                {
                    brokenPosFromRight = pos;
                }
            }

            if (brokenPosFromLeft != InvalidBrokenPos &&
                brokenPosFromRight != InvalidBrokenPos &&
                brokenPosFromLeft >= brokenPosFromRight)
            {
                brokenPosFromLeft = width;
                brokenPosFromRight = 1;
            }
        }
        Console.Write(sb);
    }
}