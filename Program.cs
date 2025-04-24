using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const char Mine = '*';

        const int Offsets = 8;
        int[] RowOffsets = new int[Offsets] { -1, 1, 0, 0, -1, -1, 1, 1 };
        int[] ColOffsets = new int[Offsets] { 0, 0, -1, 1, -1, 1, -1, 1 };

        int n = int.Parse(Console.ReadLine()!); // [1, 10]

        char[,] map = new char[n, n];
        for (int row = 0; row < n; ++row)
        {
            string s = Console.ReadLine()!;
            for (int col = 0; col < n; ++col)
            {
                map[row, col] = s[col];
            }
        }

        bool exploded = false;
        char[,] simulated = new char[n, n];
        for (int row = 0; row < n; ++row) // max tc = 10
        {
            string s = Console.ReadLine()!;
            for (int col = 0; col < n; ++col) // max tc = 10
            {
                char attr;
                if (s[col] == 'x')
                {
                    if (map[row, col] == Mine)
                    {
                        attr = Mine;
                        exploded = true;
                    }
                    else
                    {
                        int count = 0;
                        for (int i = 0; i < Offsets; ++i) // max tc = 8
                        {
                            int adjRow = row + RowOffsets[i];
                            if (adjRow < 0 || adjRow > n - 1)
                                continue;

                            int adjCol = col + ColOffsets[i];
                            if (adjCol < 0 || adjCol > n - 1)
                                continue;

                            if (map[adjRow, adjCol] != Mine)
                                continue;

                            ++count;
                        }
                        attr = (char)(count + '0');
                    }
                }
                else
                {
                    attr = '.';
                }
                simulated[row, col] = attr;
            }
        }

        if (exploded)
        {
            for (int row = 0; row < n; ++row)
            {
                for (int col = 0; col < n; ++col)
                {
                    if (map[row, col] == Mine)
                    {
                        simulated[row, col] = Mine;
                    }
                }
            }
        }

        StringBuilder sb = new();
        for (int row = 0; row < n; ++row)
        {
            for (int col = 0; col < n; ++col)
            {
                sb.Append(simulated[row, col]);
            }
            sb.AppendLine();
        }
        Console.Write(sb);
    }
}