class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine()!;

        int inputLength = input.Length;

        int a;
        int b;
        if (inputLength == 2)
        {
            a = input[0] - '0';
            b = input[1] - '0';
        }
        else if (inputLength == 3)
        {
            if (input[1] == '0')
            {
                a = 10;
                b = input[2] - '0';
            }
            else
            {
                a = input[0] - '0';
                b = 10;
            }
        }
        else // if (inputLength == 4)
        {
            a = 10;
            b = 10;
        }
        Console.Write(a + b);
    }
}