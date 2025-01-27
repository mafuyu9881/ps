internal class Program
{
    private static int _n = 0;
    private static int _sols = 0;

    private static void Main(string[] args)
    {
        _n = int.Parse(Console.ReadLine()!); // [2, 100]

        Solve(1, 1, 1); // row and col are 1-based

        Console.Write(_sols);
    }

    private static void Solve(int r, int c0, int c1)
    {
        if (r == _n)
        {
            _sols = (_sols + 2) % 10007;
            return;
        }

        // down, down
        if (c0 < c1)
        {
            Solve(r + 1, c0, c1);
        }

        // down, diagonal
        // if (c1 < _n) // it's guaranteed
        {
            Solve(r + 1, c0, c1 + 1);
        }

        // diagonal, down
        if (c1 - c0 > 1)
        {
            Solve(r + 1, c0 + 1, c1);
        }

        // diagonal, diagonal
        if (c0 < c1)
        {
            Solve(r + 1, c0 + 1, c1 + 1);
        }
    }
}