using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const int Size = 3;
        const char Blank = '-';
        const int Invalid = -1;

        bool TryWinVertical(char[,] map, char desiredMark)
        {
            for (int col = 0; col < Size; ++col)
            {
                int desiredMarkCount = 0;
                int blankCount = 0;
                int blankRow = Invalid;
                int blankCol = Invalid;
                for (int row = 0; row < Size; ++row)
                {
                    char existingMark = map[row, col];
                    if (existingMark == desiredMark)
                    {
                        ++desiredMarkCount;
                    }
                    else if (existingMark == Blank)
                    {
                        blankRow = row;
                        blankCol = col;
                        ++blankCount;
                    }
                }
                if (desiredMarkCount == 2 && blankCount == 1)
                {
                    map[blankRow, blankCol] = desiredMark;
                    return true;
                }
            }
            return false;
        }

        bool TryWinHorizontal(char[,] map, char desiredMark)
        {
            for (int row = 0; row < Size; ++row)
            {
                int desiredMarkCount = 0;
                int blankCount = 0;
                int blankRow = Invalid;
                int blankCol = Invalid;
                for (int col = 0; col < Size; ++col)
                {
                    char existingMark = map[row, col];
                    if (existingMark == desiredMark)
                    {
                        ++desiredMarkCount;
                    }
                    else if (existingMark == Blank)
                    {
                        blankRow = row;
                        blankCol = col;
                        ++blankCount;
                    }
                }
                if (desiredMarkCount == 2 && blankCount == 1)
                {
                    map[blankRow, blankCol] = desiredMark;
                    return true;
                }
            }
            return false;
        }

        bool TryWinLeftDiagonal(char[,] map, char desiredMark)
        {
            int desiredMarkCount = 0;
            int blankCount = 0;
            int blankRow = Invalid;
            int blankCol = Invalid;
            for (int offset = 0; offset < Size; ++offset)
            {
                int row = offset;
                int col = (Size - 1) - offset;
                char existingMark = map[row, col];
                if (existingMark == desiredMark)
                {
                    ++desiredMarkCount;
                }
                else if (existingMark == Blank)
                {
                    blankRow = row;
                    blankCol = col;
                    ++blankCount;
                }
            }
            if (desiredMarkCount == 2 && blankCount == 1)
            {
                map[blankRow, blankCol] = desiredMark;
                return true;
            }
            return false;
        }

        bool TryWinRightDiagonal(char[,] map, char desiredMark)
        {
            int desiredMarkCount = 0;
            int blankCount = 0;
            int blankRow = Invalid;
            int blankCol = Invalid;
            for (int offset = 0; offset < Size; ++offset)
            {
                int row = offset;
                int col = offset;
                char existingMark = map[row, col];
                if (existingMark == desiredMark)
                {
                    ++desiredMarkCount;
                }
                else if (existingMark == Blank)
                {
                    blankRow = row;
                    blankCol = col;
                    ++blankCount;
                }
            }
            if (desiredMarkCount == 2 && blankCount == 1)
            {
                map[blankRow, blankCol] = desiredMark;
                return true;
            }
            return false;
        }

        int t = int.Parse(Console.ReadLine()!);

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = ?
        {
            char[,] map = new char[Size, Size];
            for (int row = 0; row < Size; ++row) // max tc = 3
            {
                string line = Console.ReadLine()!;
                for (int col = 0; col < Size; ++col) // max tc = 3
                {
                    map[row, col] = line[col];
                }
            }

            char newMark = Console.ReadLine()![0];

            bool won = false;
            if (won == false)
            {
                won = TryWinVertical(map, newMark);
            }
            if (won == false)
            {
                won = TryWinHorizontal(map, newMark);
            }
            if (won == false)
            {
                won = TryWinLeftDiagonal(map, newMark);
            }
            if (won == false)
            {
                won = TryWinRightDiagonal(map, newMark);
            }

            sb.AppendLine($"Case {i + 1}:");
            for (int row = 0; row < Size; ++row)
            {
                for (int col = 0; col < Size; ++col)
                {
                    sb.Append($"{map[row, col]}");
                }
                sb.AppendLine();
            }
        }
        Console.Write(sb);
    }
}