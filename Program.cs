// 3 ≤ N ≤ 5000

internal class Program
{
    private static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);

        int big_bag_size = 5;
        int small_bag_size = 3;

        int tno_bags = -1;
        
        for (int i = 0; i * big_bag_size <= n; ++i)
        {
            int remain_sugar = n - (i * big_bag_size);

            if (remain_sugar % small_bag_size != 0)
                continue;

            tno_bags = i; // tno_big_big
            tno_bags += remain_sugar / small_bag_size; // tno_small_bag
        }
        
        Console.Write(tno_bags);
    }
}