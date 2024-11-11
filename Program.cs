internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);

        int n = tokens[0];
        int m = tokens[1];

        int[] requirements = new int[n];
        for (int i = 0; i < n; ++i)
        {
            requirements[i] = int.Parse(Console.ReadLine()!);
        }

        int low = 1 - 1;
        int high = requirements.Sum() + 1;
        while (low + 1 < high)
        {
            int mid = (low + high) / 2; // withdrawal amount;

            int holdingMoney = 0;
            int withdrawalCount = 0;
            for (int i = 0; i < requirements.Length; ++i)
            {
                int requirement = requirements[i];

                if (holdingMoney < requirement)
                {
                    if (mid < requirement)
                    {
                        withdrawalCount = m + 1; // make an error intentionally
                        break;
                    }

                    holdingMoney = mid - requirement;
                    ++withdrawalCount;
                }
                else
                {
                    holdingMoney -= requirement;
                }
            }

            if (withdrawalCount > m)
            {
                low = mid;
            }
            else
            {
                high = mid;
            }
        }
        Console.Write(high);
    }
}