using System.Text;

internal class Program
{
    const int InitialRollScore = 1;
    const int InitialRollScoreSum = 0;
    const int InitialTurnTime = 4;
    const int InitialElapsedTurnTime = 0;

    private static int[] _rewards = new int[4];

    private static int _rollScore;
    private static int _rollScoreSum;
    private static int _turnTime;
    private static int _elapsedTurnTime;

    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100'000]

        // length = [1, 100'000]
        // element = [1, 6]
        int[] rolls = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        Initialize();

        for (int i = 0; i < rolls.Length; ++i) // max tc = 100'000
        {
            if (_elapsedTurnTime > 240)
            {
                Grant();
                Initialize();
            }

            int roll = rolls[i];

            if (roll == 1)
            {
                Grant();
                Initialize();
                continue;
            }
            else if (roll == 2)
            {
                if (_rollScore > 1)
                {
                    _rollScore /= 2;
                }
                else
                {
                    _turnTime += 2;
                }
            }
            else if (roll == 3)
            {

            }
            else if (roll == 4)
            {
                _elapsedTurnTime += 56;
            }
            else if (roll == 5)
            {
                if (_turnTime > 1)
                {
                    --_turnTime;
                }
            }
            else if (roll == 6)
            {
                if (_rollScore < 32)
                {
                    _rollScore *= 2;
                }
            }

            _rollScoreSum += _rollScore;
            _elapsedTurnTime += _turnTime;
        }
        
        StringBuilder sb = new();
        for (int i = 0; i < _rewards.Length; ++i)
        {
            sb.AppendLine($"{_rewards[i]}");
        }
        Console.Write(sb);
    }

    private static void Initialize()
    {
        _rollScore = InitialRollScore;
        _rollScoreSum = InitialRollScoreSum;
        _turnTime = InitialTurnTime;
        _elapsedTurnTime = InitialElapsedTurnTime;
    }

    private static void Grant()
    {
        if (_rollScoreSum >= 35 && _rollScoreSum < 65)
        {
            ++_rewards[0];
        }
        else if (_rollScoreSum >= 65 && _rollScoreSum < 95)
        {
            ++_rewards[1];
        }
        else if (_rollScoreSum >= 95 && _rollScoreSum < 125)
        {
            ++_rewards[2];
        }
        else if (_rollScoreSum >= 125)
        {
            ++_rewards[3];
        }
    }
}