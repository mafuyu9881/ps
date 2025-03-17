internal class Program
{
    private static void Main(string[] args)
    {
        // length = 2
        // element = [0, 10^3)
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int a = tokens[0];
        int b = tokens[1];

        int r = int.Parse(Console.ReadLine()!); // [1, 10^3]

        int[,] map = new int[r, r];

        map[a, b] += 1;
        
        int t = 0;
        while (true)
        {
            ++t;

            if ((a + 1) + (b + 1) >= r)
            {
                a = a / 2;
                b = b / 2;
            }
            else
            {
                a = a + 1;
                b = b + 1;
            }

            map[a, b] += 1;

            if (map[a, b] > 1)
                break;
        }
        Console.Write(t);
    }
}