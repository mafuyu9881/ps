using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<int> hset = new();

        for (int i = 0; i < 10; ++i)
        {
            string input = Console.ReadLine()!;
            
            string[] tokens = input.Split();
            if (tokens == null || tokens.Length < 1)
                continue;

            hset.Add(int.Parse(tokens[0]) % 42);
        }

        Console.Write(hset.Count);
    }
}