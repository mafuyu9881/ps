internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // [2, 30'000]
        int d = tokens[1]; // [2, 3'000]
        int k = tokens[2]; // [2, 3'000]
        int c = tokens[3]; // [1, d] = [1, 3'000]

        int[] dishes = new int[n];
        {
            for (int i = 0; i < n; ++i)
            {
                dishes[i] = int.Parse(Console.ReadLine()!);
            }
        }

        int maxDiversity = 0;
        {
            int diversity = 1; // coupon count
            
            int[] counts = new int[d + 1];
            Action<int> AddCount = (dish) =>
            {
                if (counts[dish] < 1)
                {
                    ++diversity;

                    if (dish == c)
                    {
                        --diversity;
                    }
                }
                
                ++counts[dish];
            };
            Action<int> RemoveCount = (dish) =>
            {
                --counts[dish];

                if (counts[dish] < 1)
                {
                    --diversity;

                    if (dish == c)
                    {
                        ++diversity;
                    }
                }
            };

            int right = 0;
            for (int i = 0; i < k; ++i)
            {
                right = (0 + i) % dishes.Length;
                int dish = dishes[right];
                AddCount(dish);
            }

            maxDiversity = Math.Max(maxDiversity, diversity);

            for (int left = 0; left < dishes.Length; ++left)
            {
                int leftDish = dishes[left];
                RemoveCount(leftDish);

                right = (right + 1) % dishes.Length;
                int rightDish = dishes[right];
                AddCount(rightDish);

                maxDiversity = Math.Max(maxDiversity, diversity);
            }
        }
        Console.Write(maxDiversity);
    }
}