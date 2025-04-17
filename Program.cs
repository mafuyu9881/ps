using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] WordTable = new string[] { "V", "딸기" };

        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            int n = int.Parse(Console.ReadLine()!) % 28;

            if (n == 0)
            {
                n = 2;
            }

            if (n > 15)
            {
                n = 30 - n;
            }

            LinkedList<int> bits = ConvertDecimalToBinary(n);

            StringBuilder message = new();
            for (var lln = bits.First; lln != null; lln = lln.Next)
            {
                message.Append(WordTable[lln.Value]);
            }
            output.AppendLine($"{message}");
        }
        Console.Write(output);
    }

    private static LinkedList<int> ConvertDecimalToBinary(int n)
    {
        LinkedList<int> bits = new();
        while (n > 0)
        {
            bits.AddFirst(n % 2);
            n /= 2;
        }
        while (bits.Count < 4)
        {
            bits.AddFirst(0);
        }
        return bits;
    }
}