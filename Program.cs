internal class Program
{
    const int Blank = 0;
    const int Wall = 1;
    const int Virus = 2;
    const int Infested = 3;

    private static int _height = 0;
    private static int _width = 0;
    private static bool[] _occupied = null!;
    private static int[] _map = null!;
    private static LinkedList<int> _viruses = new();
    
    private const int Offsets = 4;
    private static int[] _rowOffsets = new int[Offsets] { -1, 1, 0, 0 };
    private static int[] _colOffsets = new int[Offsets] { 0, 0, -1, 1 };

    private static int _maxSafety = 0;

    private static void Main(string[] args)
    {
        // length = 2
        // element = [3, 8]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        _height = tokens[0];
        _width = tokens[1];

        _occupied = new bool[_height * _width];

        _map = new int[_height * _width];

        for (int row = 0; row < _height; ++row) // max tc = 8
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < _width; ++col) // max tc = 8
            {
                int index = row * _width + col;

                int attr = tokens[col];
                if (attr == Virus)
                {
                    _viruses.AddLast(index);
                }

                _map[index] = tokens[col];
            }
        }

        Simulate(1, 0);

        Console.Write(_maxSafety);
    }
    
    // depth has 1-based value
    private static void Simulate(int depth, int beginIndex)
    {
        for (int i = beginIndex; i < _map.Length; ++i) // max tc = 64
        {
            if (_map[i] == Wall ||
                _map[i] == Virus)
                continue;

            _occupied[i] = true;

            if (depth < 3)
            {
                Simulate(depth + 1, i + 1);
            }
            else
            {
                for (int j = 0; j < _map.Length; ++j) // max tc = 64
                {
                    if (_map[j] == Infested)
                    {
                        _map[j] = Blank;
                    }
                }

                for (var lln = _viruses.First; lln != null; lln = lln.Next) // max tc = 64
                {
                    Queue<int> frontier = new();
                    frontier.Enqueue(lln.Value);

                    while (frontier.Count > 0) // max tc = 64
                    {
                        int index = frontier.Dequeue();
                        int row = index / _width;
                        int col = index % _width;
                        
                        for (int j = 0; j < Offsets; ++j)
                        {
                            int adjRow = row + _rowOffsets[j];
                            if (adjRow < 0 || adjRow > _height - 1)
                                continue;

                            int adjCol = col + _colOffsets[j];
                            if (adjCol < 0 || adjCol > _width - 1)
                                continue;

                            int adjIndex = adjRow * _width + adjCol;
                            if (_occupied[adjIndex] ||
                                _map[adjIndex] == Wall ||
                                _map[adjIndex] == Virus ||
                                _map[adjIndex] == Infested)
                                continue;

                            _map[adjIndex] = Infested;
                            frontier.Enqueue(adjIndex);
                        }
                    }
                }

                int safety = 0;
                for (int j = 0; j < _map.Length; ++j)
                {
                    if (_occupied[j])
                        continue;

                    if (_map[j] != Blank)
                        continue;

                    ++safety;
                }
                _maxSafety = Math.Max(_maxSafety, safety);
            }

            _occupied[i] = false;
        }
    }
}