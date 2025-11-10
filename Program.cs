class Program
{
    static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int c1 = 0;
        int c2 = 0;
        for (int i = 0; i < tokens.Length; ++i)
        {
            if (tokens[i] == 1)
            {
                ++c1;
            }
            else
            {
                ++c2;
            }
        }
        Console.Write((c1 > c2) ? 1 : 2);
    }
}