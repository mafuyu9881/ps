internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int[] requestedBudgets = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int requestedBudgetsLength = requestedBudgets.Length;

        int budget = int.Parse(Console.ReadLine()!);

        int output;
        if (requestedBudgets.Sum() > budget)
        {
            int low = 1 - 1;
            int high = budget - (requestedBudgetsLength - 1) + 1;
            while (low < high - 1)
            {
                int mid = (low + high) / 2;

                int spentBudget = 0;
                for (int i = 0; i < requestedBudgetsLength; ++i)
                {
                    int requestedBudget = requestedBudgets[i];

                    spentBudget += Math.Min(mid, requestedBudget);
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
            output = low;
        }
        else
        {
            output = requestedBudgets.Max();
        }
        Console.Write(output);
    }
}