using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder output = new();

        string? a_s = Console.ReadLine();
        string? b_s = Console.ReadLine();
        string? c_s = Console.ReadLine();
        
        int? a_n = GetNumberFromString(a_s);
        int? b_n = GetNumberFromString(b_s);
        int? c_n = GetNumberFromString(c_s);
        if (a_n == null || b_n == null || c_n == null)
            return;

        output.AppendLine((a_n + b_n - c_n).ToString());
        output.Append(int.Parse(a_s + b_s) - c_n);

        Console.Write(output);
    }

    private static int? GetNumberFromString(string? s)
    {
        if (string.IsNullOrEmpty(s))
            return null;

        return int.Parse(s);
    }
}

//Console.ReadKey();