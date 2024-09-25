internal class Program
{
    private static void Main(string[] args)
    {
        int k = int.Parse(Console.ReadLine()!);

        Stack<int> stack = new();
        for (int i = 0; i < k; ++i)
        {
            int n = int.Parse(Console.ReadLine()!);

            if (n != 0)
            {
                stack.Push(n);
            }
            else
            {
                stack.Pop();
            }
        }

        int sum = 0;
        while (stack.Count > 0)
        {
            sum += stack.Pop();
        }
        Console.Write(sum);
    }
}