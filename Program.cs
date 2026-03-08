public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int y0 = tokens[0];
        int m0 = tokens[1];
        int d0 = tokens[2];

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int y1 = tokens[0];
        int m1 = tokens[1];
        int d1 = tokens[2];

        DateTime today = new DateTime(y0, m0, d0);
        DateTime dday = new DateTime(y1, m1, d1);

        string output;
        if ((y1 > y0 + 1000) ||
            (y1 == y0 + 1000 && m1 > m0) ||
            (y1 == y0 + 1000 && m1 == m0 && d1 >= d0))
        {
            output = "gg";
        }
        else
        {
            output = $"D-{(dday - today).Days}";
        }
        Console.Write(output);
    }
}