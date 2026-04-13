public class Program
{
    public static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0];
        
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int odds = 0;
        int evens = 0;
        for (int i = 0; i < n; ++i)
        {
            if (tokens[i] % 2 == 0)
            {
                ++evens;
            }
            else
            {
                ++odds;
            }
        }

        Console.Write((evens > odds) ? "Happy" : "Sad");
    }
}