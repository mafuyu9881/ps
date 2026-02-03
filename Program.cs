using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine()!);

        StringBuilder output = new();
        for (int i = 0; i < t; ++i)
        {
            Console.ReadLine();

            long n = long.Parse(Console.ReadLine()!);

            long moddedCandies = 0;
            for (int j = 0; j < n; ++j)
            {
                moddedCandies = (moddedCandies + (long.Parse(Console.ReadLine()!) % n)) % n;
            }

            output.AppendLine((moddedCandies == 0) ? "YES" : "NO");
        }
        Console.Write(output);
    }
}