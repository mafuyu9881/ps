using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        StringBuilder input = new(Console.ReadLine()!);
        input.Append('\0');
        int output = 0;
        bool minusFlag = false;
        StringBuilder sb = new();
        for (int i = 0; i < input.Length; ++i)
        {
            char c = input[i];

            if (c < '0')
            {
                if (sb.Length > 0)
                {
                    output += Math.Abs(int.Parse(sb.ToString())) * (minusFlag ? -1 : 1);
                    sb.Clear();
                }

                minusFlag |= c == '-';
            }

            sb.Append(c);
        }
        Console.Write(output);
    }
}