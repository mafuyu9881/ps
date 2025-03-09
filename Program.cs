using System.Text;

internal class Program
{
    const int Size = 9;
    
    private static bool[] _contained = new bool[Size + 1];

    private static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!); // [1, 100]

        int[,] board = new int[Size, Size];

        StringBuilder sb = new();
        for (int i = 0; i < t; ++i) // max tc = 100
        {
            if (i > 0)
            {
                Console.ReadLine();
            }
            
            for (int row = 0; row < Size; ++row) // tc = 9
            {
                int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
                for (int col = 0; col < Size; ++col) // tc = 9
                {
                    board[row, col] = tokens[col];
                }
            }

            bool correct = true;

            for (int row = 0; row < Size; ++row) // tc = 9
            {
                ClearContained();
                for (int col = 0; col < Size; ++col) // tc = 9
                {
                    int n = board[row, col];

                    if (_contained[n])
                    {
                        correct = false;
                        goto Evaluate;
                    }

                    _contained[n] = true;
                }
            }

            for (int col = 0; col < Size; ++col) // tc = 9
            {
                ClearContained();
                for (int row = 0; row < Size; ++row) // tc = 9
                {
                    int n = board[row, col];

                    if (_contained[n])
                    {
                        correct = false;
                        goto Evaluate;
                    }

                    _contained[n] = true;
                }
            }

            for (int rowBasis = 0; rowBasis < Size; rowBasis += 3) // tc = 3
            {
                for (int colBasis = 0; colBasis < Size; colBasis += 3) // tc = 3
                {
                    ClearContained();
                    for (int rowOffset = 0; rowOffset < 3; ++rowOffset) // tc = 3
                    {
                        for (int colOffset = 0; colOffset < 3; ++colOffset) // tc = 3
                        {
                            int n = board[rowBasis + rowOffset, colBasis + colOffset];

                            if (_contained[n])
                            {
                                correct = false;
                                goto Evaluate;
                            }

                            _contained[n] = true;
                        }
                    }
                }
            }
            
Evaluate:
            sb.Append($"Case {i + 1}: ");
            sb.AppendLine(correct ? "CORRECT" : "INCORRECT");
        }
        Console.Write(sb);
    }

    private static void ClearContained()
    {
        for (int i = 1; i < _contained.Length; ++i) // tc = 9
        {
            _contained[i] = false;
        }
    }
}