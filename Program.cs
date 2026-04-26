public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int d = 0;
        int p = 0;
        for (int i = 0; i < n; ++i)
        {
            if (Console.ReadLine()! == "D")
            {
                ++d;
            }
            else
            {
                ++p;
            }

            if (Math.Abs(p - d) >= 2)
            {
                break;
            }
        }
        
        Console.Write($"{d}:{p}");
    }
}