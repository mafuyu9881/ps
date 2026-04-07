public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        
        int refused = 0;
        for (int i = 0; i < n; ++i)
        {
            int d = int.Parse(Console.ReadLine()!);
            if (d % 2 != 0)
            {
                ++refused;
            }
        }

        Console.Write(refused);
    }
}