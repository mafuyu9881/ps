public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int output = 0;
        for (int i = 0; i < n; ++i)
        {
            int xi = int.Parse(Console.ReadLine()!.Substring(2));
            if (xi > 90)
                continue;
            
            ++output;
        }
        
        Console.Write(output);
    }
}