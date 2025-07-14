class Program
{
    static void Main(string[] args)
    {
        int[] tokens = null!;

        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 20]
        int k = tokens[1]; // [1, 22]

        (int w, int s, int e)[] wses = new (int, int, int)[n];
        for (int i = 0; i < n; ++i) // max tc = 20
        {
            tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
            int w = tokens[0]; // [1, 5]
            int s = tokens[1]; // [1, 10]
            int e = tokens[2]; // [1, 10]
            wses[i] = (w, s, e);
        }

        int cases = 0;
        {
            int score = 0;

            int[,] occupied = new int[4 + 1, 10 + 1];

            Action<int> Solve = null!;
            Solve = (int beginIndex) =>
            {
                for (int i = beginIndex; i < n; ++i) // max tc = 20
                {
                    var wse = wses[i];
                    int w = wse.w;
                    int s = wse.s;
                    int e = wse.e;

                    if (w == 5)
                        continue;

                    bool occupiable = true;
                    for (int j = s; j <= e; ++j) // max tc = 10
                    {
                        if (occupied[w, j] > 0)
                        {
                            occupiable = false;
                            break;
                        }
                    }

                    if (occupiable)
                    {
                        int earned = e - s + 1;

                        for (int j = s; j <= e; ++j) // max tc = 10
                        {
                            ++occupied[w, j];
                        }
                        score += earned;

                        if (score == k)
                        {
                            ++cases;
                        }
                        else
                        {
                            Solve(i + 1);
                        }

                        score -= earned;
                        for (int j = s; j <= e; ++j) // max tc = 10
                        {
                            --occupied[w, j];
                        }
                    }
                }
            };
            Solve(0);
        }
        Console.Write(cases);
    }
}