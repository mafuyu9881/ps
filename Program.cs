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

        (int s, int e)[] fromSEs = new (int, int)[]
        {
            (tokens[0], tokens[1]),
            (tokens[2], tokens[3]),
            (tokens[4], tokens[5]),
        };

        //int veryEnd = (fromSEs[2].s + fromSEs[0].s, fromSEs[2].e + fromSEs[0].e), 1339;

        (int s, int e)[] toSEs = new (int, int)[]
        {
            fromSEs[1],
            fromSEs[2],
            (fromSEs[2].s + fromSEs[0].s, fromSEs[2].e + fromSEs[0].e),
        };


    }
}