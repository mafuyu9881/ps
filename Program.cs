using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        const int MaxDays = 641;

        int n = int.Parse(Console.ReadLine()!); // [1, 5'000]

        string paper = Console.ReadLine()!;

        int currIndex = 0;
        int soldiers = 0;
        while (currIndex < paper.Length) // max tc = 5'000
        {
            StringBuilder daysSB = new();
            for (int subIndex = currIndex; subIndex < paper.Length && subIndex < currIndex + 3; ++subIndex)
            {
                daysSB.Append(paper[subIndex]);
            }

            int nextIndex = currIndex + daysSB.Length;
            while ((int.Parse($"{daysSB}") > MaxDays) || (nextIndex < paper.Length && paper[nextIndex] == '0'))
            {
                daysSB = daysSB.Remove(daysSB.Length - 1, 1);
                nextIndex = currIndex + daysSB.Length;
            }

            ++soldiers;

            currIndex = nextIndex;
        }
        Console.Write(soldiers);
    }
}