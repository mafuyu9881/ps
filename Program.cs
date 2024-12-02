using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string s = Console.ReadLine()!;
        int xCount = 0;
        StringBuilder output = new();
        for (int i = 0; i < s.Length; ++i)
        {
            char c = s[i];

            if (c == 'X')
            {
                ++xCount;
            }

            if ((xCount % 2 != 0) &&
                (c == '.' || i == (s.Length - 1)))
            {
                output.Clear();
                output.Append("-1");
                break;
            }

            if (xCount == 4)
            {
                output.Append("AAAA");
                xCount = 0;
            }

            if ((xCount == 2) &&
                (i == (s.Length - 1) || c == '.'))
            {
                output.Append("BB");
                xCount = 0;
            }

            if ((xCount == 0) &&
                (c == '.'))
            {
                output.Append('.');
            }
        }
        Console.Write(output);
    }
}