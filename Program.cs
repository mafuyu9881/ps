public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int t1 = tokens[0];
        int e1 = tokens[1];
        int f1 = tokens[2];
        int sum1 = t1 * 3 + e1 * 20 + f1 * 120;
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int t2 = tokens[0];
        int e2 = tokens[1];
        int f2 = tokens[2];
        int sum2 = t2 * 3 + e2 * 20 + f2 * 120;
        
        string output;
        if (sum1 > sum2)
        {
            output = "Max";
        }
        else if (sum1 < sum2)
        {
            output = "Mel";
        }
        else
        {
            output = "Draw";
        }
        Console.Write(output);
    }
}