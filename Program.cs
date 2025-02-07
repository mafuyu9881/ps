using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string s = Console.ReadLine()!;

        char converter = (char)('a' - 'A');

        StringBuilder sb = new();
        for (int i = 0; i < s.Length; ++i)
        {
            char c = s[i];

            if (c < 'a')
            {
                c += converter;
            }
            else
            {
                c -= converter;
            }

            sb.Append(c);
        }
        Console.Write(sb);
    }
}