internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int k = tokens[1];

        bool[] brokenTrafficLights = new bool[n];
        for (int i = 0; i < tokens[2]; ++i)
        {
            brokenTrafficLights[int.Parse(Console.ReadLine()!) - 1] = true;
        }

        int minRepairs = 0;
        int lastRepairs = 0;
        for (int i = 0; i <= n - k; ++i)
        {
            if (i == 0)
            {
                for (int j = i; j < i + k; ++j)
                {
                    lastRepairs += ConvertBrokenFlagToInteger(brokenTrafficLights[j]);
                }
                minRepairs = lastRepairs;
            }
            else
            {
                lastRepairs -= ConvertBrokenFlagToInteger(brokenTrafficLights[i - 1]);
                lastRepairs += ConvertBrokenFlagToInteger(brokenTrafficLights[i + k - 1]);
                minRepairs = Math.Min(minRepairs, lastRepairs);
            }
        }
        Console.Write(minRepairs);
    }

    private static int ConvertBrokenFlagToInteger(bool input)
    {
        return input ? 1 : 0;
    }
}