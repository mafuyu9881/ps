internal class Program
{
    private static void Main(string[] args)
    {
        string s = Console.ReadLine()!;

        for (int digit = 1; digit <= 3; ++digit)
        {
            int reader = 0;

            int startN = 0;
            while (reader < digit)
            {
                startN *= 10;
                startN += s[reader] - '0';
                ++reader;
            }

            int objectiveN = startN + 1;
            
            bool succeeded = true;
            while (reader < s.Length)
            {
                string objectiveNS = objectiveN.ToString();

                int parsedN = 0;
                for (int i = 0; i < objectiveNS.Length && reader < s.Length; ++i)
                {
                    parsedN *= 10;
                    parsedN += s[reader] - '0';
                    ++reader;
                }

                if (objectiveN == parsedN)
                {
                    ++objectiveN;
                }
                else
                {
                    succeeded = false;
                    break;
                }
            }

            if (succeeded)
            {
                Console.Write($"{startN} {objectiveN - 1}");
                break;
            }
        }
    }
}