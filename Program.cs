internal class Program
{
    const int EscapableDistance = 25;

    private static LinkedList<(int row, int col)> _others = new();
    private static (int row, int col) _sungkyu = (0, 0);
    private static (int row, int col) _professor = (0, 0);

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [7, 1'000]

        for (int row = 0; row < n; ++row) // max tc = 1'000
        {
            // length = [1, n] = [1, 1'000]
            // element = 0, 1, 2, 5
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            for (int col = 0; col < n; ++col) // max tc = 1'000
            {
                int attr = tokens[col];

                if (attr == 1)
                {
                    _others.AddLast((row, col));
                }
                else if (attr == 2)
                {
                    _sungkyu = (row, col);
                }
                else if (attr == 5)
                {
                    _professor = (row, col);
                }
            }
        }

        Console.Write(Evaluate());
    }

    private static int Evaluate()
    {
        const int Succeeded = 1;
        const int Failed = 0;

        int distance = ComputeDistance(_sungkyu, _professor);
        if (distance < EscapableDistance)
            return Failed;

        (int row, int col) lt = (Math.Min(_sungkyu.row, _professor.row), Math.Min(_sungkyu.col, _professor.col));
        (int row, int col) rb = (Math.Max(_sungkyu.row, _professor.row), Math.Max(_sungkyu.col, _professor.col));

        int bounded = 0;
        for (var lln = _others.First; lln != null; lln = lln.Next) // max tc = about 1'000'000
        {
            var other = lln.Value;

            if (other.row < lt.row || other.row > rb.row)
                continue;

            if (other.col < lt.col || other.col > rb.col)
                continue;

            ++bounded;
        }

        return (bounded < 3) ? Failed : Succeeded;
    }

    private static int ComputeDistance((int x, int y) a, (int x, int y) b)
    {
        return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
    }
}