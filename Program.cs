using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int x = tokens[0]; // [1, 100]
        int y = tokens[1]; // [1, 100]
        
        int lcm = LCM(x, y);

        StringBuilder output = new();
        for (int i = 1; i <= lcm; ++i)
        {
            bool left = i % (lcm / x) == 0;
            bool right = i % (lcm / y) == 0;

            if (left && right)
            {
                output.Append('3');
            }
            else if (left)
            {
                output.Append('1');
            }
            else if (right)
            {
                output.Append('2');
            }
        }
        Console.Write(output);
    }

    private static int GCD(int a, int b)
    {
        int bigger = Math.Max(a, b);
        int smaller = Math.Min(a, b);

        while (smaller > 0)
        {
            int temp = bigger % smaller;
            bigger = smaller;
            smaller = temp;
        }

        return bigger;
    }
    
    private static int LCM(int a, int b)
    {
        return a * b * GCD(a, b);
    }
}