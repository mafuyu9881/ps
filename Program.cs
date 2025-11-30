class Program
{
    static void Main(string[] args)
    {
        const string LionName = "Lion";
        const string TigerName = "Tiger";

        int lionCount = 0;
        int tigerCount = 0;
        for (int i = 0; i < 9; ++i)
        {
            if (Console.ReadLine()! == LionName)
            {
                ++lionCount;
            }
            else
            {
                ++tigerCount;
            }
        }

        string king;
        if (lionCount > tigerCount)
        {
            king = LionName;
        }
        else
        {
            king = TigerName;
        }
        Console.Write(king);
    }
}