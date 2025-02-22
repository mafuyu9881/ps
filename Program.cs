internal class Program
{
    private static void Main(string[] args)
    {
        string token = Console.ReadLine()!;

        int invalidBrackets = 0;
        int leftBrackets = 0;
        for (int i = 0; i < token.Length; ++i)
        {
            char c = token[i];
            if (c == '(')
            {
                ++leftBrackets;
            }
            else // if (c == ')')
            {
                if (leftBrackets > 0)
                {
                    --leftBrackets;
                }
                else
                {
                    ++invalidBrackets;
                }
            }
        }
        Console.Write(invalidBrackets + leftBrackets);
    }
}