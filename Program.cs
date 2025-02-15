using System.Text;

internal class Program
{
    private static int _side;
    private static int[] _map = null!;

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 6]
        int q = tokens[1]; // [1, 1'000]

        _side = ExponentationBySquaringIteratively(2, n); // [4, 64]

        _map = new int[_side * _side];
        LinkedList<int> candidates = new();
        for (int row = 0; row < _side; ++row) // max tc = 64
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < _side; ++col) // max tc = 64
            {
                int index = row * _side + col;
                _map[index] = tokens[col];
                candidates.AddLast(index);
            }
        }

        const int AdjOffsets = 4;
        int[] adjRowOffsets = new int[AdjOffsets] { -1, 1, 0, 0 };
        int[] adjColOffsets = new int[AdjOffsets] { 0, 0, -1, 1 };

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        for (int i = 0; i < tokens.Length; ++i) // max tc = 1'000
        {
            int l = tokens[i]; // [0, 6]
            
            if (l > 0) // may we unify this condition with the logic below?
            {

                int stride = ExponentationBySquaringIteratively(2, l); // [2, 64]

                // tc
                // = 32 * 32 * (2 / 2) * (2 / 2) = 1 * 1 * (64 / 2) * (64 / 2)
                // = 16 * 16 * (4 / 2) * (4 / 2) = ... = 1'024
                for (int beginRow = 0; beginRow < _side; beginRow += stride)
                {
                    for (int beginCol = 0; beginCol < _side; beginCol += stride)
                    {
                        for (int rowOffset = 0; rowOffset < stride / 2; ++rowOffset)
                        {
                            for (int colOffset = 0; colOffset < stride / 2; ++colOffset)
                            {
                                int primaryLocalRow = rowOffset;
                                int primaryLocalCol = colOffset;
                                int secondaryLocalRow = primaryLocalCol;
                                int secondaryLocalCol = Reverse(stride, primaryLocalRow);
                                int tertiaryLocalRow = secondaryLocalCol;
                                int tertiaryLocalCol = Reverse(stride, secondaryLocalRow);
                                int quaternaryLocalRow = tertiaryLocalCol;
                                int quaternaryLocalCol = Reverse(stride, tertiaryLocalRow);

                                int primaryGlobalRow = beginRow + primaryLocalRow;
                                int primaryGlobalCol = beginCol + primaryLocalCol;
                                int primaryGlobalIndex = primaryGlobalRow * _side + primaryGlobalCol;
                                int secondaryGlobalRow = beginRow + secondaryLocalRow;
                                int secondaryGlobalCol = beginCol + secondaryLocalCol;
                                int secondaryGlobalIndex = secondaryGlobalRow * _side + secondaryGlobalCol;
                                int tertiaryGlobalRow = beginRow + tertiaryLocalRow;
                                int tertiaryGlobalCol = beginCol + tertiaryLocalCol;
                                int tertiaryGlobalIndex = tertiaryGlobalRow * _side + tertiaryGlobalCol;
                                int quaternaryGlobalRow = beginRow + quaternaryLocalRow;
                                int quaternaryGlobalCol = beginCol + quaternaryLocalCol;
                                int quaternaryGlobalIndex = quaternaryGlobalRow * _side + quaternaryGlobalCol;

                                int primary = _map[primaryGlobalIndex];
                                int secondary = _map[secondaryGlobalIndex];
                                int tertiary = _map[tertiaryGlobalIndex];
                                int quaternary = _map[quaternaryGlobalIndex];

                                _map[primaryGlobalIndex] = quaternary;
                                _map[secondaryGlobalIndex] = primary;
                                _map[tertiaryGlobalIndex] = secondary;
                                _map[quaternaryGlobalIndex] = tertiary;
                            }
                        }
                    }
                }
            }            

            LinkedList<int> meltedIndices = new();
            for (int row = 0; row < _side; ++row) // max tc = 64
            {
                for (int col = 0; col < _side; ++col) // max tc = 64
                {
                    int adjIces = 0;
                    for (int j = 0; j < AdjOffsets; ++j)
                    {
                        int adjRow = row + adjRowOffsets[j];
                        if (adjRow < 0 || adjRow > _side - 1)
                            continue;

                        int adjCol = col + adjColOffsets[j];
                        if (adjCol < 0 || adjCol > _side - 1)
                            continue;

                        int adjIndex = adjRow * _side + adjCol;
                        if (_map[adjIndex] < 1)
                            continue;

                        ++adjIces;
                    }

                    if (adjIces > 2)
                        continue;

                    meltedIndices.AddLast(row * _side + col);
                }
            }

            for (var lln = meltedIndices.First; lln != null; lln = lln.Next)
            {
                _map[lln.Value] = Math.Max(0, _map[lln.Value] - 1);
            }
        }

        Queue<int> frontier = new();
        bool[] visited = new bool[_map.Length];
        LinkedList<LinkedList<int>> chunks = new(); // not necessary for this time
        LinkedList<int> maxChunk = new();
        LinkedList<int> chunk = null!;

        int ices = 0;
        while (true) // max tc = 4'096
        {
            if (frontier.Count < 1)
            {
                if (candidates.Count < 1)
                    break;

                var lln = candidates.First!;
                int candidateIndex = lln.Value;
                candidates.Remove(lln);
                if (visited[candidateIndex])
                    continue;

                if (_map[candidateIndex] < 1)
                    continue;

                chunk = new();
                chunks.AddLast(chunk);
                visited[candidateIndex] = true;
                frontier.Enqueue(candidateIndex);
            }

            int index = frontier.Dequeue();
            int row = index / _side;
            int col = index % _side;

            ices += _map[index];
            chunk.AddLast(index);
            if (chunk.Count > maxChunk.Count)
            {
                maxChunk = chunk;
            }

            for (int i = 0; i < AdjOffsets; ++i) // tc = 4
            {
                int adjRow = row + adjRowOffsets[i];
                if (adjRow < 0 || adjRow > _side - 1)
                    continue;

                int adjCol = col + adjColOffsets[i];
                if (adjCol < 0 || adjCol > _side - 1)
                    continue;

                int adjIndex = adjRow * _side + adjCol;
                if (visited[adjIndex])
                    continue;

                if (_map[adjIndex] < 1)
                    continue;

                visited[adjIndex] = true;
                frontier.Enqueue(adjIndex);
            }
        }

        StringBuilder sb = new();
        sb.AppendLine($"{ices}");
        sb.AppendLine($"{maxChunk.Count}");
        Console.Write(sb);
    }

    private static int ExponentationBySquaringIteratively(int basis, int exponent)
    {
        int output = 1;
        while (exponent > 0)
        {
            if (exponent % 2 == 1)
            {
                output *= basis;
            }
            basis *= basis;
            exponent >>= 1;
        }
        return output;
    }

    private static int Reverse(int side, int attribute)
    {
        return side - 1 - attribute;
    }
}