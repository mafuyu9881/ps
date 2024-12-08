internal class Program
{
    private static void Main(string[] args)
    {
        int[] tokens = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        int n = tokens[0]; // m < n ≤ 10
        int m = tokens[1]; // 1 ≤ m < n

        int basketStart = 0;

        int j = int.Parse(Console.ReadLine()!);

        int moves = 0;
        for (int i = 0; i < j; ++i)
        {
            int fallingPoint = int.Parse(Console.ReadLine()!) - 1;

            while (fallingPoint < basketStart ||
                   fallingPoint > basketStart + m - 1)
            {
                basketStart += Math.Sign(fallingPoint - basketStart);
                ++moves;
            }
        }
        Console.Write(moves);
    }
}