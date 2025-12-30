class Program
{
    static void Main(string[] args)
    {
        int blackScoreSum = 0;
        int whiteScoreSum = 0;

        for (int row = 0; row < 8; ++row)
        {
            string s = Console.ReadLine()!;
            for (int col = 0; col < 8; ++col)
            {
                char c = s[col];

                int score = 0;
                if (c == 'p' || c == 'P')
                {
                    score = 1;
                }
                else if (c == 'n' || c == 'N')
                {
                    score = 3;
                }
                else if (c == 'b' || c == 'B')
                {
                    score = 3;
                }
                else if (c == 'r' || c == 'R')
                {
                    score = 5;
                }
                else if (c == 'q' || c == 'Q')
                {
                    score = 9;
                }

                if (c >= 'a')
                {
                    blackScoreSum += score;
                }
                else
                {
                    whiteScoreSum += score;
                }
            }
        }

        Console.Write(whiteScoreSum - blackScoreSum);
    }
}