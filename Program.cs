class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()!);
        int[] results = Array.ConvertAll(Console.ReadLine()!.Split(), int.Parse);
        
        int score = 0;
        int streak = 0;
        for (int i = 0; i < results.Length; ++i)
        {
            int result = results[i];

            if (result == 1)
            {
                ++streak;
            }
            else
            {
                streak = 0;
            }

            score += streak;
        }

        Console.Write(score);
    }
}