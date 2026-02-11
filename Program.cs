using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string octal = Console.ReadLine()!;

        StringBuilder output = new();
        for (int i = 0; i < octal.Length; ++i)
        {
            int digit = octal[i] - '0';
            output.Append((digit >> 2) & 1);
            output.Append((digit >> 1) & 1);
            output.Append((digit >> 0) & 1);
        }

        int readStartIndex = 0;
        while (readStartIndex < output.Length - 1)
        {
            if (output[readStartIndex] != '0')
                break;
            
            ++readStartIndex;
        }

        Console.Write(output.ToString(readStartIndex, output.Length - readStartIndex));
    }
}