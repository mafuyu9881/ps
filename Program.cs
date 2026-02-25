class Program
{
    static void Main(string[] args)
    {
        // 1-based

        int x = int.Parse(Console.ReadLine()!);

        int diagonalRow = 1;
        int lastIndexUntilPrevDiagonalRow = 0;

        while (diagonalRow + lastIndexUntilPrevDiagonalRow < x)
        {
            lastIndexUntilPrevDiagonalRow += diagonalRow;
            diagonalRow += 1;
        }

        int diagonalCol = x - lastIndexUntilPrevDiagonalRow;

        int numerator = diagonalRow - diagonalCol + 1;
        int denominator = diagonalCol;
        if (diagonalRow % 2 == 0)
        {
            int temp = numerator;
            numerator = denominator;
            denominator = temp;
        }

        Console.Write($"{numerator}/{denominator}");
    }
}