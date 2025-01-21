internal class Program
{
    private const int Vacated = 0;
    private const int Occupied = 1;

    private static int _height;
    private static int _width;

    private static int[,] _map = null!;

    private static int[,] _solidity = null!;
    
    // type a = ┓, b = ┛, c = ┗, d = ┏
    private static (int row, int col)[] _aOffsets = new (int, int)[] { (0, 0), (0, 1), (1, 1) };
    private static (int row, int col)[] _bOffsets = new (int, int)[] { (1, 0), (1, 1), (0, 1) };
    private static (int row, int col)[] _cOffsets = new (int, int)[] { (0, 0), (1, 0), (1, 1) };
    private static (int row, int col)[] _dOffsets = new (int, int)[] { (1, 0), (0, 0), (0, 1) };

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        _height = tokens[0];
        _width = tokens[1];

        _map = new int[_height, _width];

        _solidity = new int[_height, _width];
        for (int row = 0; row < _height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < _width; ++col)
            {
                _solidity[row, col] = tokens[col];
            }
        }

        int maxSolidities = 0;
        int solidities = 0;
        Solve(ref maxSolidities, ref solidities);
        Console.Write(maxSolidities);
    }

    private static void Solve(ref int maxSolidities, ref int solidities)
    {
        for (int row = 0; row < _height - 1; ++row)
        {
            for (int col = 0; col < _width - 1; ++col)
            {
                if (Placeable(_aOffsets, row, col))
                {
                    solidities += Write(_aOffsets, row, col, Occupied);
                    maxSolidities = Math.Max(maxSolidities, solidities);
                    Solve(ref maxSolidities, ref solidities);
                    solidities -= Write(_aOffsets, row, col, Vacated);
                }

                if (Placeable(_bOffsets, row, col))
                {
                    solidities += Write(_bOffsets, row, col, Occupied);
                    maxSolidities = Math.Max(maxSolidities, solidities);
                    Solve(ref maxSolidities, ref solidities);
                    solidities -= Write(_bOffsets, row, col, Vacated);
                }

                if (Placeable(_cOffsets, row, col))
                {
                    solidities += Write(_cOffsets, row, col, Occupied);
                    maxSolidities = Math.Max(maxSolidities, solidities);
                    Solve(ref maxSolidities, ref solidities);
                    solidities -= Write(_cOffsets, row, col, Vacated);
                }

                if (Placeable(_dOffsets, row, col))
                {
                    solidities += Write(_dOffsets, row, col, Occupied);
                    maxSolidities = Math.Max(maxSolidities, solidities);
                    Solve(ref maxSolidities, ref solidities);
                    solidities -= Write(_dOffsets, row, col, Vacated);
                }
            }
        }
    }
    
    private static bool Placeable((int row, int col)[] offsets, int basisRow, int basisCol)
    {
        for (int i = 0; i < offsets.Length; ++i)
        {
            var offset = offsets[i];

            int row = basisRow + offset.row;
            if (row > _height - 1)
                return false;

            int col = basisCol + offset.col;
            if (col > _width - 1)
                return false;

            if (_map[row, col] == Occupied)
                return false;
        }

        return true;
    }

    private static int Write((int row, int col)[] offsets, int basisRow, int basisCol, int state)
    {
        int solidities = 0;

        for (int i = 0; i < offsets.Length; ++i)
        {
            var offset = offsets[i];

            // it is guaranteed that row and col are valid here
            int row = basisRow + offset.row;
            int col = basisCol + offset.col;

            _map[row, col] = state;

            solidities += _solidity[row, col] * ((i != 1) ? 1 : 2);
        }

        return solidities;
    }
}