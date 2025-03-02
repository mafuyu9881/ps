using System.Text;

internal class Program
{
    private const string NullPointerException = "NullPointerException";
    private const string False = "false";
    private const string True = "true";

    private static void Main(string[] args)
    {
        string? a = ReadToken();
        string? b = ReadToken();

        StringBuilder sb = new();
        sb.AppendLine(Equals(a, b, false));
        sb.AppendLine(Equals(a, b, true));
        Console.Write(sb);
    }

    private static string? ReadToken()
    {
        string token = Console.ReadLine()!;
        return (token != "null") ? token : null;
    }

    private static string Equals(string? a, string? b, bool ignoreCase)
    {
        if (a == null)
            return NullPointerException;

        if (b == null)
            return False;

        if (a.Length != b.Length)
            return False;

        for (int i = 0; i < a.Length; ++i)
        {
            if (Equals(a[i], b[i], ignoreCase) == false)
            {
                return False;
            }
        }

        return True;
    }

    private static bool Equals(char a, char b, bool ignoreCase)
    {
        if (ignoreCase && IsNumber(a) == false && IsNumber(b) == false)
        {
            a = AdjustToLowerCase(a);
            b = AdjustToLowerCase(b);
        }

        return a == b;
    }
    
    private static bool IsNumber(char c)
    {
        return c >= '0' && c <= '9';
    }

    private static char AdjustToLowerCase(char c)
    {
        if (c >= 'a' && c <= 'z')
        {
            return c;
        }
        else
        {
            return (char)(c - 'A' + 'a');
        }
    }
}