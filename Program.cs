internal class Program
{
    private static void Main(string[] args)
    {
        const int Tries = 18;

        int[][] combination = new int[Tries + 1][];
        combination[0] = new int[] { 1 };
        combination[1] = new int[] { 1, 1 };
        for (int i = 2; i < combination.Length; ++i)
        {
            combination[i] = new int[i + 1];
            
            combination[i][0] = 1;
            combination[i][i] = 1;

            for (int j = 1; j < i; ++j)
            {
                combination[i][j] = combination[i - 1][j - 1] + combination[i - 1][j];
            }
        }

        int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17 };
        // int[] composites = new int[] { 0, 1, 4, 6, 8, 9, 10, 12, 14, 15, 16, 18}; // actually, 0 is not contained in the composite number but, let's just let it slide in this time

        double teamAGoalChance = double.Parse(Console.ReadLine()!) / 100; // [0.0, 1.0]
        double teamBGoalChance = double.Parse(Console.ReadLine()!) / 100; // [0.0, 1.0]

        double teamAPrimeProbability = 0.0;
        double teamBPrimeProbability = 0.0;
        for (int i = 0; i < primes.Length; ++i)
        {
            int r = primes[i];
            teamAPrimeProbability += combination[Tries][r] * Math.Pow(teamAGoalChance, r) * Math.Pow(1 - teamAGoalChance, Tries - r);
            teamBPrimeProbability += combination[Tries][r] * Math.Pow(teamBGoalChance, r) * Math.Pow(1 - teamBGoalChance, Tries - r);
        }
        
        double output = 0;
        output += teamAPrimeProbability * teamBPrimeProbability;
        output += teamAPrimeProbability * (1 - teamBPrimeProbability);
        output += (1 - teamAPrimeProbability) * teamBPrimeProbability;
        Console.Write(output == 0 ? "0.0" : output);
    }
}