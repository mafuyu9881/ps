internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 1'000'000]

        for (int i = 0; i < n; ++i) // max tc = 1'000'000
        {
            // length = 2
            int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

            int a = tokens[0];
            int b = tokens[1];

            for (int j = 0; j <= b / 2; ++j)
            {
                Adjust(b - j);
                Adjust(b + j);
            }
        }
    }

    private static int Adjust(int degree)
    {
        while (degree < 0)
        {
            degree += 360;
        }
        
        while (degree >= 360)
        {
            degree -= 360;
        }

        return degree;
    }
}