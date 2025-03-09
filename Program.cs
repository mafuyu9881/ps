internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!); // [1, 3'000]

        // element = [1, 10^8]
        int[] xs = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // max tc = 3'000
        int[] ts = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse); // max tc = 3'000

        (int x, int t)[] xts = new (int, int)[n];
        for (int i = 0; i < n; ++i) // max tc = 3'000
        {
            int x = xs[i];
            int t = ts[i];
            xts[i] = (x, t);
        }
        Array.Sort(xts, (a, b) => a.x.CompareTo(b.x));

        bool[] picked = new bool[n];

        int truckX = 0;
        long elapsedT = 0;

        for (int i = 0; i < n; ++i) // max tc = 3'000
        {
            int currX = xts[i].x;

            int deltaT = currX - truckX;
            int currT = xts[i].t;

            elapsedT += deltaT;

            if (elapsedT >= currT)
            {
                picked[i] = true;
            }
            
            truckX = currX;
        }

        for (int i = n - 1; i >= 0; --i) // max tc = 3'000
        {
            if (picked[i])
                continue;

            int currX = xts[i].x;

            int deltaT = truckX - currX;
            int currT = xts[i].t;

            elapsedT += deltaT;

            if (elapsedT < currT)
            {
                elapsedT = currT;
            }

            picked[i] = true;
            truckX = currX;
        }
        
        elapsedT += truckX;
        truckX = 0;

        Console.Write(elapsedT);
    }
}