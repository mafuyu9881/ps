public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] preferences = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        Console.Write
        (
            Math.Min(preferences[0], n) +
            Math.Min(preferences[1], n) +
            Math.Min(preferences[2], n)
        );
    }
}