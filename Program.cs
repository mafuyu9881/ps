class Program
{
    static void Main(string[] args)
    {
        const char teamA = 'A';
        const char teamB = 'B';

        string input = Console.ReadLine()!;

        int scoreA = 0;
        int scoreB = 0;

        for (int i = 0; i < input.Length / 2; ++i)
        {
            char team = input[i * 2 + 0];
            int score = int.Parse($"{input[i * 2 + 1]}");

            if (team == teamA)
            {
                scoreA += score;
            }
            else
            {
                scoreB += score;
            }
        }

        Console.Write((scoreA > scoreB) ? teamA : teamB);
    }
}