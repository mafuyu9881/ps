public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        int m = tokens[1];
        
        int boxes = n / m;
        if (n % m > 0)
        {
            ++boxes;
        }

        Console.Write(boxes);
    }
}