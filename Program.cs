using System.Text;

internal class Program
{
    private static int[] _zero = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _one = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _two = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _three = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _four = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 1, 1, 0, 0,
        0, 1, 0, 1, 0, 0,
        1, 1, 1, 1, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _five = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 0, 0,
        0, 0, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 0, 1, 1, 0, 0,
    };

    private static int[] _six = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _seven = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 1, 0, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _eight = new int[]
    {
        0, 0, 0, 0, 0, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 0, 0,
    };

    private static int[] _nine = new int[]
    {
        0, 1, 1, 1, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 0, 0, 1, 0,
        0, 1, 1, 1, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
        0, 0, 0, 0, 1, 0,
    };

    private static int[][] _numbers = new int[10][]
    {
        _zero,
        _one,
        _two,
        _three,
        _four,
        _five,
        _six,
        _seven,
        _eight,
        _nine,
    };

    private static int _cellWidth = 6;
    private static int _cellHeight = 7;
    private static int _boardWidth = 0;
    private static int _boardHeight = 7;
    private static int[][] _board = new int[_boardHeight][];

    private static int _n = 0; // [1, 10]

    private static int[] _availables = new int[10];
    private static Queue<int> _currPermutationQueue = new();
    private static int[] _currPermutation = null!;
    private static int[] _nextPermutation = null!;

    private static void Main(string[] args)
    {
        for (int row = 0; row < _board.Length; ++row) // tc = 7
        {
            string s = Console.ReadLine()!;

            _boardWidth = s.Length;

            int[] line = new int[_boardWidth];
            for (int col = 0; col < _boardWidth; ++col) // max tc = 60
            {
                line[col] = s[col] - '0';
            }
            _board[row] = line;
        }

        _n = _boardWidth / _cellWidth;

        _currPermutation = new int[_n];

        for (int col = 0; col < _boardWidth; col += _cellWidth) // max tc = 10
        {
            int number = Evaluate(col);
            ++_availables[number];
            _currPermutationQueue.Enqueue(number);
            _currPermutation[col / _cellWidth] = number;
        }

        ComputeNextPermutation(1);

        StringBuilder sb = new();
        if (_nextPermutation == null)
        {
            sb.Append("The End");
        }
        else
        {
            for (int row = 0; row < _boardHeight; ++row)
            {
                for (int col = 0; col < _boardWidth; ++col)
                {
                    int number = _nextPermutation[col / _cellWidth];
                    int index = row * _cellWidth + col % _cellWidth;
                    sb.Append(_numbers[number][index]);
                }
                sb.AppendLine();
            }
        }
        Console.Write(sb);
    }

    private static int Evaluate(int startCol)
    {
        int evaluated = -1;

        for (int i = 0; i < _numbers.Length; ++i) // tc = 10
        {
            int[] number = _numbers[i];

            bool match = true;
            for (int index = 0; index < _cellWidth * _cellHeight; ++index) // tc = 42
            {
                int row = index / _cellWidth;
                int col = index % _cellWidth;

                if (number[index] == _board[row][startCol + col])
                    continue;

                match = false;
                break;
            }

            if (match == false)
                continue;

            evaluated = i;
            break;
        }

        return evaluated;
    }
    
    private static void ComputeNextPermutation(int depth) // depth is 1-based
    {
        int number = 0;
        if (_currPermutationQueue.Count > 0)
            number = _currPermutationQueue.Dequeue();

        for (; number < 10; ++number)
        {
            if (_availables[number] < 1)
                continue;

            --_availables[number];

            if ((depth == _n) && (number != _currPermutation[depth - 1]))
            {
                _nextPermutation = new int[_n];
            }

            if (depth < _n)
            {
                ComputeNextPermutation(depth + 1);
            }

            if (_nextPermutation != null)
            {
                _nextPermutation[depth - 1] = number;
            }

            ++_availables[number];

            if (_nextPermutation != null)
            {
                return;
            }
        }
    }
}