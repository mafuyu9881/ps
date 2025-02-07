internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int k = tokens[1]; // [1, 1'440]
        
        const int DayMinutes = 1440;

        // element = [0, 1'440)
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int breakfastS = tokens[0];
        int breakfastE = tokens[1];
        int lunchS = tokens[2];
        int lunchE = tokens[3];
        int dinnerS = tokens[4];
        int dinnerE = tokens[5];

        (int s, int e)[] ses = new (int, int)[]
        {
            (breakfastS, breakfastE),
            (lunchS, lunchE),
            (dinnerS, dinnerE),
        };

        bool[] availables = new bool[DayMinutes];
        for (int i = 0; i < ses.Length; ++i) // tc = 3
        {
            int s = ses[i].s;
            int e = ses[i].e;
            for (int j = s; j <= e; ++j) // max tc = 1438
            {
                availables[j] = true;
            }
        }

        bool continuous = false;
        for (int i = breakfastS; i <= breakfastE; ++i) // max tc = 1438
        {
            int afterBreakfast = (i + k) % DayMinutes;
            //if (i == afterBreakfast)
            //{
            //    continuous = true;
            //    break;
            //}
            if (availables[afterBreakfast] == false)
                continue;
            
            int afterLunch = (i + (2 * k)) % DayMinutes;
            if (availables[afterLunch] == false)
                continue;

            int afterDinner = (i + (3 * k)) % DayMinutes;
            if ((n == 1) && ((i + (3 * k)) >= 1439))
                continue;

            //if ((n > 1) && )
            //    continue;
        }
    }
}