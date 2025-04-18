using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        SortedDictionary<char, int> Indices = new()
        {
            { 'q', 0 },
            { 'u', 1 },
            { 'a', 2 },
            { 'c', 3 },
            { 'k', 4 },
        };

        // length = [5, 2'500]
        // element = q, u, a, c, k
        string s = Console.ReadLine()!;

        int[] count = new int[5];

        int ducksPeak = 0;
        {
            int ducks = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                char c = s[i];

                int currIndex = Indices[c];

                if (currIndex <= 0)
                {
                    ++count[currIndex];
                    ++ducks;
                }
                else
                {
                    int prevIndex = currIndex - 1;

                    if (count[prevIndex] > 0)
                    {
                        --count[prevIndex];
                    }
                    else
                    {
                        ducksPeak = -1;
                        break;
                    }

                    if (currIndex < 4)
                    {
                        ++count[currIndex];
                    }
                    else
                    {
                        --ducks;
                    }
                }
                ducksPeak = Math.Max(ducksPeak, ducks);
            }
        }
        Console.Write(ducksPeak);
    }
}