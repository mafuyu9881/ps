using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine()!);
        int b = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        output.AppendLine($"{a * GetDigit(b, 10, 1)}");
        output.AppendLine($"{a * GetDigit(b, 100, 10)}");
        output.AppendLine($"{a * GetDigit(b, 1000, 100)}");
        output.AppendLine($"{a * b}");
        Console.Write(output);
    }

    static int GetDigit(int n, int modulus, int divisor)
    {
        return (n % modulus) / divisor;
    }
}