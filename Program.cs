internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 100]

        // length = [1, 100]
        // element = [-100, 100]
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int v = int.Parse(Console.ReadLine()!); // [-100, 100]

        int output = 0;
        for (int i = 0; i < tokens.Length; ++i)
        {
            if (tokens[i] == v)
            {
                ++output;
            }
        }
        Console.Write(output);
    }
}