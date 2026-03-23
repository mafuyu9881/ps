using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        StringBuilder output = new();
        {
            int[] tokens = null!;
            int t, f, s, p, c;

            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            t = tokens[0];
            f = tokens[1];
            s = tokens[2];
            p = tokens[3];
            c = tokens[4];
            output.Append($"{t * 6 + f * 3 + s * 2 + p * 1 + c * 2} ");

            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            t = tokens[0];
            f = tokens[1];
            s = tokens[2];
            p = tokens[3];
            c = tokens[4];
            output.Append($"{t * 6 + f * 3 + s * 2 + p * 1 + c * 2} ");
        }
        Console.Write(output);
    }
}