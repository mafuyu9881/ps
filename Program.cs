internal class Program
{
    private static int _height;
    private static int _width;

    private static bool[,] _occupied = null!;

    private static int[,] _solidity = null!;
    
    // a = ┓, b = ┛, c = ┗, d = ┏
    private static (int row, int col)[] _compA = new (int, int)[] { (0, 0), (0, 1), (1, 1) };
    private static (int row, int col)[] _compB = new (int, int)[] { (1, 0), (1, 1), (0, 1) };
    private static (int row, int col)[] _compC = new (int, int)[] { (0, 0), (1, 0), (1, 1) };
    private static (int row, int col)[] _compD = new (int, int)[] { (1, 0), (0, 0), (0, 1) };

    private static int _maxSolidities = 0;

    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        _height = tokens[0];
        _width = tokens[1];

        _occupied = new bool[_height, _width];

        _solidity = new int[_height, _width];
        for (int row = 0; row < _height; ++row)
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < _width; ++col)
            {
                _solidity[row, col] = tokens[col];
            }
        }

        Place(0, 0, 0);
        Console.Write(_maxSolidities);
    }

    private static void Place(int solidities, int row, int col)
    {
        _maxSolidities = Math.Max(_maxSolidities, solidities);

        if (col >= _height - 1) // no need to check the last col
        {
            ++row;
            col = 0;
        }

        if (row >= _height - 1) // also no need to check the last row
            return;

        void TryPlace((int row, int col)[] comp)
        {
            if (Placeable(comp, row, col) == false)
                return;

            solidities += Occupy(comp, row, col);
            Place(solidities, row, col + 1);
            solidities -= Vacate(comp, row, col);
        }

        TryPlace(_compA);
        TryPlace(_compB);
        TryPlace(_compC);
        TryPlace(_compD);

        Place(solidities, row, col + 1);
    }

    private static bool Placeable((int row, int col)[] comp, int basisRow, int basisCol)
    {
        for (int i = 0; i < comp.Length; ++i)
        {
            var part = comp[i];

            int row = basisRow + part.row;
            if (row > _height - 1)
                return false;

            int col = basisCol + part.col;
            if (col > _width - 1)
                return false;

            if (_occupied[row, col])
                return false;
        }

        return true;
    }

    private static int Occupy((int row, int col)[] comp, int basisRow, int basisCol)
    {
        return Write(comp, basisRow, basisCol, true);
    }
    private static int Vacate((int row, int col)[] comp, int basisRow, int basisCol)
    {
        return Write(comp, basisRow, basisCol, false);
    }
    private static int Write((int row, int col)[] comp, int basisRow, int basisCol, bool state)
    {
        int solidities = 0;

        for (int i = 0; i < comp.Length; ++i)
        {
            var part = comp[i];

            // it's guaranteed that row and col are valid here
            int row = basisRow + part.row;
            int col = basisCol + part.col;

            _occupied[row, col] = state;
            solidities += _solidity[row, col] * ((i == 1) ? 2 : 1);
        }

        return solidities;
    }
}