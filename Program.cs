internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [1, 100'000]
        int k = tokens[1]; // [1, 1'440]
        
        const int DayMinutes = 1440;

        bool[] breakfastAvailables = new bool[DayMinutes];
        bool[] lunchAvailables = new bool[DayMinutes];
        bool[] dinnerAvailables = new bool[DayMinutes];

        // element = [0, 1'440)
        tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int breakfastS = tokens[0];
        int breakfastE = tokens[1];
        int lunchS = tokens[2];
        int lunchE = tokens[3];
        int dinnerS = tokens[4];
        int dinnerE = tokens[5];

        bool[][] allAvailables = new bool[][]
        {
            breakfastAvailables,
            lunchAvailables,
            dinnerAvailables
        };
        for (int i = 0; i < tokens.Length; i += 2) // tc = 3
        {
            bool[] availables = allAvailables[i / 2];
            int mealStart = tokens[i];
            int mealEnd = tokens[i + 1];

            for (int j = mealStart; j <= mealEnd; ++j)
            {
                availables[j] = true;
            }
        }
    }
}