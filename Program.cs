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
        int breakfastBegin = tokens[0];
        int breakfastEnd = tokens[1];
        int lunchBegin = tokens[2];
        int lunchEnd = tokens[3];
        int dinnerBegin = tokens[4];
        int dinnerEnd = tokens[5];

        (int s, int e)[] bes = new (int, int)[]
        {
            (breakfastBegin, breakfastEnd),
            (lunchBegin, lunchEnd),
            (dinnerBegin, dinnerEnd),
        };

        bool[] availables = new bool[DayMinutes];
        for (int i = 0; i < bes.Length; ++i) // tc = 3
        {
            int s = bes[i].s;
            int e = bes[i].e;
            for (int j = s; j <= e; ++j) // max tc = 1438
            {
                availables[j] = true;
            }
        }

        bool continuous = false;
        for (int i = breakfastBegin; i <= breakfastEnd; ++i) // max tc = 1438
        {
            int breakfastDrugEnd = i + k - 1;

            for (int j = lunchBegin; j <= lunchEnd; ++j)
            {
                if (breakfastDrugEnd < j - 1)
                    continue;

                int lunchDrugEnd = j + k - 1;

                for (int l = dinnerBegin; l <= dinnerEnd; ++l)
                {
                    if (lunchDrugEnd < l - 1)
                        continue;

                    int dinnerDrugEnd = l + k - 1;

                    int objectiveMinutes;
                    if (n > 1)
                        objectiveMinutes = DayMinutes + breakfastBegin;
                    else
                        objectiveMinutes = DayMinutes - 1;

                    if (dinnerDrugEnd < objectiveMinutes - 1)
                        continue;

                    continuous = true;
                    goto Print;
                }
            }
        }

Print:
        Console.Write(continuous ? "YES" : "NO");
    }
}