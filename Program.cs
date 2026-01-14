using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] digitWidths = { 4, 2, 3, 3, 3, 3, 3, 3, 3, 3 };

        StringBuilder output = new();
        while (true)
        {
            string s = Console.ReadLine()!;
            if (s == "0")
                break;

            int width = s.Length + 1;
            for (int i = 0; i < s.Length; ++i)
            {
                int digit = s[i] - '0';
                width += digitWidths[digit];
            }
            
            output.AppendLine($"{width}");
        }
        Console.Write(output);
    }
}