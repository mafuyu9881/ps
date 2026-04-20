public class Program
{
    public static void Main(string[] args)
    {
        string mbti = Console.ReadLine()!;

        int matches = 0;
        {
            int n = int.Parse(Console.ReadLine()!);
            for (int i = 0; i < n; ++i)
            {
                if (mbti == Console.ReadLine()!)
                {
                    ++matches;
                }
            }
        }

        Console.Write(matches);
    }
}