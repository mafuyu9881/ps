using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        BitArray bits = new(10000000 + 1);

        int number = 0;

        while (true)
        {
            int c = Console.Read();
            if (c == -1)
                break;
            
            if (c == ' ')
            {
                if (bits[number])
                {
                    Console.Write(number);
                    break;
                }
                else
                {
                    bits[number] = true;
                }
                number = 0;
            }
            else
            {
                number = number * 10 + c - '0';
            }
        }
    }
}