class Program
{
    static void Main(string[] args)
    {
        string formula = Console.ReadLine()!;

        const int delimiter = -1;

        Stack<int> stack = new();
        for (int i = 0; i < formula.Length; ++i)
        {
            char c = formula[i];

            if (c == 'H')
            {
                stack.Push(1);
            }
            else if (c == 'C')
            {
                stack.Push(12);
            }
            else if (c == 'O')
            {
                stack.Push(16);
            }
            else if (c == '(')
            {
                stack.Push(delimiter);
            }
            else if (c == ')')
            {
                int sum = 0;
                while (stack.Peek() != delimiter)
                {
                    sum += stack.Pop();
                }
                stack.Pop();
                stack.Push(sum);
            }
            else
            {
                stack.Push(stack.Pop() * (c - '0'));
            }
        }

        int weight = 0;
        while (stack.Count > 0)
        {
            weight += stack.Pop();
        }
        Console.Write(weight);
    }
}