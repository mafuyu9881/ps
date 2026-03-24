public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];
        int c = tokens[2];

        string output;
        if (a + b == c ||
            b + c == a ||
            c + a == b)
        {
            output = "1";
        }
        else if (a * b == c ||
                 b * c == a ||
                 c * a == b)
        {
            output = "2";
        }
        else
        {
            output = "3";
        }
        Console.Write(output);
    }
}