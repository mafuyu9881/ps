using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int password_min_length = 6;
        int password_max_length = 9;

        int n = int.Parse(Console.ReadLine()!);
        
        StringBuilder output = new();
        for (int i = 0; i < n; ++i)
        {
            string password = Console.ReadLine()!;
            int password_length = password.Length;
            if (password_length >= password_min_length &&
                password_length <= password_max_length)
            {
                output.AppendLine("yes");
            }
            else
            {
                output.AppendLine("no");
            }
        }
        Console.Write(output);
    }
}