internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] requestedBudgets = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int budget = int.Parse(Console.ReadLine()!);

        int low = 1 - 1;
        int high = requestedBudgets.Max() + 1;
        while (low < high - 1)
        {
            int mid = (low + high) / 2;

            int spentBudget = 0;
            for (int i = 0; i < requestedBudgets.Length; ++i)
            {
                spentBudget += Math.Min(mid, requestedBudgets[i]);
            }

            if (spentBudget > budget)
            {
                high = mid;
            }
            else
            {
                low = mid;
            }
        }
        Console.Write(low);
    }
}