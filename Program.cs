using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        // length = [1, 100'000]
        // element = [1, 6]
        int[] rolls = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int[] rewards = new int[4];

        const int InitialRollScore = 1;
        const int InitialRollScoreSum = 0;
        const int InitialTurnTime = 4;
        const int InitialElapsedTurnTime = 0;

        int rollScore = InitialRollScore;
        int rollScoreSum = InitialRollScoreSum;
        int turnTime = InitialTurnTime;
        int elapsedTurnTime = InitialElapsedTurnTime;

        for (int i = 0; i < rolls.Length; ++i) // max tc = 100'000
        {
            int roll = rolls[i];

            bool finish = false;

            if (roll == 1)
            {
                finish = true;
            }
            else if (roll == 2)
            {
                if (rollScore > 1)
                {
                    rollScore /= 2;
                }
                else
                {
                    turnTime += 2;
                }
            }
            else if (roll == 3)
            {

            }
            else if (roll == 4)
            {
                elapsedTurnTime += 56;
            }
            else if (roll == 5)
            {
                if (turnTime > 1)
                {
                    --turnTime;
                }
            }
            else // if (roll == 6)
            {
                if (rollScore < 32)
                {
                    rollScore *= 2;
                }
            }

            if (elapsedTurnTime > 240)
            {
                finish = true;
            }

            if (finish)
            {
                if (rollScoreSum >= 35 && rollScoreSum < 65)
                {
                    ++rewards[0];
                }
                else if (rollScoreSum >= 65 && rollScoreSum < 95)
                {
                    ++rewards[1];
                }
                else if (rollScoreSum >= 95 && rollScoreSum < 125)
                {
                    ++rewards[2];
                }
                else if (rollScoreSum >= 125)
                {
                    ++rewards[3];
                }

                rollScore = InitialRollScore;
                rollScoreSum = InitialRollScoreSum;
                turnTime = InitialTurnTime;
                elapsedTurnTime = InitialElapsedTurnTime;
            }
            else
            {
                rollScoreSum += rollScore;
                elapsedTurnTime += turnTime;
            }
        }
        
        StringBuilder sb = new();
        for (int i = 0; i < rewards.Length; ++i)
        {
            sb.AppendLine($"{rewards[i]}");
        }
        Console.Write(sb);
    }
}