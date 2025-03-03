using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // length = [2, 500]
        string token = Console.ReadLine()!;

        int zeros = 0;
        int ones = 0;
        for (int i = 0; i < token.Length; ++i) // max tc = 500
        {
            char c = token[i];
            if (c == '0')
            {
                ++zeros;
            }
            else
            {
                ++ones;
            }
        }

        zeros /= 2;
        ones /= 2;

        StringBuilder sb = new();
        for (int i = 0; i < zeros; ++i) // max tc = 250
        {
            sb.Append(0);
        }
        for (int i = 0; i < ones; ++i) // max tc = 250
        {
            sb.Append(1);
        }
        Console.Write(sb);
    }
}