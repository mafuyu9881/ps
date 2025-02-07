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

        bool continuous = false;

        int breakfastDrugEnd = breakfastEnd + k;
        if (breakfastDrugEnd < lunchBegin)
            goto Print;

        int lunchDrugEnd = Math.Min(breakfastDrugEnd, lunchEnd) + k;
        if (lunchDrugEnd < dinnerBegin)
            goto Print;

        int dinnerDrugEnd = Math.Min(lunchDrugEnd, dinnerEnd) + k;
        int objectiveMinutes = (n > 1) ? DayMinutes + breakfastBegin : DayMinutes;
        if (dinnerDrugEnd < objectiveMinutes)
            goto Print;

        continuous = true;
        
Print:
        Console.Write(continuous ? "YES" : "NO");
    }
}