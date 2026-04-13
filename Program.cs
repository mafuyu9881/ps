public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int sum = 0;
        for (int i = 0; i < n; ++i)
        {
            sum += tokens[i];
        }

        string output;
        if (sum < 0)
        {
            output = "Left";
        }
        else if (sum > 0)
        {
            output = "Right";
        }
        else
        {
            output = "Stay";
        }
        Console.Write(output);
    }
}