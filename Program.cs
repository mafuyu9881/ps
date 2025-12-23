using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n0 = tokens[0];
        int n1 = tokens[1];

        StringBuilder output = new();

        int a = 100 - n0;
        int b = 100 - n1;
        int c = 100 - (a + b);
        int d = a * b;
        int q = d / 100;
        int r = d % 100;
        output.AppendLine($"{a} {b} {c} {d} {q} {r}");
        
        output.AppendLine($"{c + q} {r}");

        Console.Write(output);
    }
}