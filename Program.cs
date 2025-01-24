internal class Program
{
    private static void Main(string[] args)
    {
        int m = int.Parse(Console.ReadLine()!);

        int[] cups = new int[] { 1, 2, 3 };
        for (int i = 0; i < m; ++i)
        {
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int x = tokens[0];
            int y = tokens[1];

            int xIndex = 0;
            int yIndex = 0;
            for (int j = 0; j < cups.Length; ++j)
            {
                if (cups[j] == x)
                {
                    xIndex = j;
                }

                if (cups[j] == y)
                {
                    yIndex = j;
                }
            }

            cups[xIndex] = y;
            cups[yIndex] = x;
        }
        Console.Write(cups[0]);
    }
}